using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using System.Data.SqlClient;
using ESRI.ArcGIS.esriSystem;


namespace DesktopWindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            axTOCControl1.SetBuddyControl(axMapControl1);
            initialzeMap();

        }
        public void RefreshStands(DataLoad dataLoad)
        {
            //�����ղ�վ������shp 
            //���ȴ����������ռ���Ϣ��OID�ֶε�shp
            DataOperator dataOperator = new DataOperator(axMapControl1.Map);
            IFeatureClass featureClass = dataOperator.CreateShapefile("D:\\", "ShapefileWorkspace", "ShapefileSample");
            if (featureClass == null)
            {
                MessageBox.Show("����shape�ļ�ʧ��");
                return;
            }

            //��������shp���վ�����ֶ�
            IFieldEdit fieldEdit = (IFieldEdit)new Field();
            fieldEdit.Name_2 = "STCD";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
            featureClass.AddField(fieldEdit as IField);
            fieldEdit = (IFieldEdit)new Field();
            fieldEdit.Name_2 = "STNM";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
            featureClass.AddField(fieldEdit as IField);
            fieldEdit = (IFieldEdit)new Field();
            fieldEdit.Name_2 = "precipitation";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
            featureClass.AddField(fieldEdit as IField);

            //�������ݿ⣬�������վ������

            SqlDataReader stands = dataLoad.ExecuteSQL("select*from վ�����Ա�");
            while (stands.Read())
            {

                IFeature feature = featureClass.CreateFeature();
                string stcd = stands["STCD"].ToString().Trim();
                string stnm = stands["STNM"].ToString().Trim();
                double lat = Convert.ToDouble(stands["LGTD"].ToString().Trim());
                double lon = Convert.ToDouble(stands["LTTD"].ToString().Trim());
                IPoint point = new ESRI.ArcGIS.Geometry.Point();
                //�����״����������Ϣ��
                point.PutCoords(lat, lon);
                feature.Shape = point;
                //��ȡ�����Ե�index������¼����ֵ
                int index = feature.Fields.FindField("STCD");
                feature.set_Value(index, stcd);
                index = feature.Fields.FindField("STNM");
                feature.set_Value(index, stnm);
                //string a=feature.get_Value(3);
                //string b=feature.get_Value(4);
                feature.Store();
            }
            stands.Close();
        }

        public void initialzeMap()
        {
            DataOperator dataOperator = new DataOperator(axMapControl1.Map);
            //���ص�ͼ��ǳ��ɫ��
            IFeatureClass basemapFeature = dataOperator.GetFeatureClass("D:\\1\\GIS\\Shape", "��������.shp");
            ISimpleRenderer simpleRenderer = new SimpleRenderer();
            ISimpleFillSymbol simpleFillSymbol = new SimpleFillSymbol();
            simpleFillSymbol.Style = esriSimpleFillStyle.esriSFSSolid;
            IRgbColor rgbColor = new RgbColor();
            rgbColor.Red = 245;
            rgbColor.Green = 245;
            rgbColor.Blue = 245;
            simpleFillSymbol.Color = rgbColor;
            simpleRenderer.Symbol = simpleFillSymbol as ISymbol;
            bool bRes = dataOperator.AddFeatureClassToMap(basemapFeature, "��ͼ", simpleRenderer as IFeatureRenderer);
            axMapControl1.Refresh();
            //����ʹ��ʱ��û�н��������վ����ļ�����Ҫ�ȸ���վ�㽨�����ļ�������������ע�͵�������
            //����Զ�����ݿ�
            DataLoad dataLoad = new DataLoad();
            //��Զ�����ݿ��ȡ������վ������shp
            RefreshStands(dataLoad);
            axMapControl1.AddShapeFile("D:\\" + "ShapefileWorkspace", "ShapefileSample");
            axMapControl1.Refresh();
        }



        public void CreatBookMark(string sBookMarkName)
        {
            //���浱ǰ�����ķ�Χ
            IAOIBookmark aoiBookmark = new AOIBookmarkClass();
            if (aoiBookmark != null)
            {
                aoiBookmark.Location = axMapControl1.ActiveView.Extent;
                aoiBookmark.Name = sBookMarkName;
            }
            //���ͼ�м�����ǩ
            IMapBookmarks bookmarks = axMapControl1.Map as IMapBookmarks;
            if (bookmarks != null)
            {
                bookmarks.AddBookmark(aoiBookmark);
            }
            //���½���ǩ������Ͽ�
            comboBox1.Items.Add(aoiBookmark.Name);
        }

        private void ������ǩToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdmitBookmarkName frmABN = new AdmitBookmarkName(this);
            frmABN.Show();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            IMapBookmarks bookmarks = axMapControl1.Map as IMapBookmarks;
            IEnumSpatialBookmark enumSpatialBookmark = bookmarks.Bookmarks;

            enumSpatialBookmark.Reset();
            ISpatialBookmark spatialBookmark = enumSpatialBookmark.Next();
            while (spatialBookmark != null)
            {
                if (comboBox1.SelectedItem.ToString() == spatialBookmark.Name)
                {
                    spatialBookmark.ZoomTo((IMap)axMapControl1.ActiveView);
                    axMapControl1.ActiveView.Refresh();
                    break;
                }
                spatialBookmark = enumSpatialBookmark.Next();

            }
        }

        private void axToolbarControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IToolbarControlEvents_OnMouseDownEvent e)
        {

        }
        private void GetPrecipitation(string s)
        {
            DataLoad dataLoad = new DataLoad();
            DataOperator dataOperator = new DataOperator(axMapControl1.Map);
            IGeoFeatureLayer geoFeatureLayer = dataOperator.GetLayerByName("ShapefileSample") as IGeoFeatureLayer;
            //����һѭ���α�
            IFeatureCursor featureCursor = geoFeatureLayer.FeatureClass.Search(null, false);
            IFeature feature;
            if (featureCursor != null)
            {

                //���ҽ�ˮ�ֶΡ�վ�����ֶε�������,arc�Զ���precipitation��Ϊprecipitat
                int fieldIndexp = geoFeatureLayer.FeatureClass.Fields.FindField("precipitat");
                int fieldIndexs = geoFeatureLayer.FeatureClass.Fields.FindField("STCD");
                //����
                while ((feature = featureCursor.NextFeature()) != null)
                {
                    string ID = feature.Value[fieldIndexs].ToString();
                    SqlDataReader dataReader = dataLoad.ExecuteSQL(s + " and STCD='" + ID + "'");
                    while (dataReader.Read())
                    {
                        string temp_p = dataReader["P"].ToString().Trim();
                        if (temp_p == "")
                            continue;
                        double p = Convert.ToDouble(temp_p);
                        double current = (double)feature.get_Value(fieldIndexp);
                        if (current == 0 || current == null)
                            feature.set_Value(fieldIndexp, p);
                        else
                            feature.set_Value(fieldIndexp, p + current);
                        feature.Store();
                    }
                    dataReader.Close();
                }
            }
        }

        private IFeatureRenderer GetDivideValueRenderer(IGeoFeatureLayer geoFeatureLayer)
        {

            if (geoFeatureLayer != null)
            {

                ILayer layer = geoFeatureLayer;
                ITable table = layer as ITable;
                //���Ȼ�÷��ŵ�����
                ISymbol symbol = MapComposer.GetSymbolFromLayer(layer);
                int classCount = 5;  //�ȼ���
                //ʵ����
                //BasicTableHistogramClass ���ñ�����������ݵĽṹ������Ȼ�ϵ㡢��λ��������ֱ��ͼ
                ITableHistogram tableHistogram = new BasicTableHistogram() as ITableHistogram;
                tableHistogram.Table = table;
                tableHistogram.Field = "precipitat";

                IBasicHistogram basicHistogram = tableHistogram as IBasicHistogram;
                //��ͳ��ÿ��ֵ���ֵĴ�����������Ϊ vakues,frequencys
                object values;
                object frequencys;
                basicHistogram.GetHistogram(out values, out frequencys);
                //IClassifyGENʵ���˶��������ݶ���ķ���(DefineInterval��EqualInterval��NatureBreaks��Quantile��StandardDeviation)
                //�˴�����һƽ���ּ�������ͳ�ƽ�����зּ�
                IClassifyGEN classifyGEN = new Quantile();
                classifyGEN.Classify(values, frequencys, ref classCount);
                double[] classes = classifyGEN.ClassBreaks as double[];

                double[] myclasses;
                myclasses = new double[classCount];
                if (classes != null)
                {
                    for (int j = 0; j < classCount; j++)
                        myclasses[j] = classes[j + 1];
                }

                //����һ��ɫö�ٱ�����ͨ��������ȡɫ��
                IEnumColors enumColors = Rendering.makeAlgorithmicColorRamp(Rendering.makeRGBColor(255, 235, 214), Rendering.makeRGBColor(196, 10, 10), classCount).Colors;
                IColor color;
                IClassBreaksRenderer classBreaksRenderer = new ClassBreaksRenderer();
                classBreaksRenderer.BreakCount = classCount; //���÷ּ���
                classBreaksRenderer.Field = "precipitat";
                classBreaksRenderer.SortClassesAscending = true; //������ʾ

                //�����еȼ�������Ⱦ��ɫ
                ISimpleMarkerSymbol simpleMarkerSymbol;
                for (int i = 0; i < myclasses.Length; i++)
                {
                    color = enumColors.Next();
                    simpleMarkerSymbol = new SimpleMarkerSymbol();
                    simpleMarkerSymbol.Color = color;
                    classBreaksRenderer.Symbol[i] = simpleMarkerSymbol as ISymbol;
                    classBreaksRenderer.Break[i] = myclasses[i];
                }

                return classBreaksRenderer as IFeatureRenderer;
            }
            else
            {
                MessageBox.Show("error");
                return null;
            }
        }

        private void СʱToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //����վ��shp�����������ֶ�
            //�˴���ʱ��Ϊ���ݿ�������һСʱ����5.23��ʮһ��Ϊ��ǰʱ�䣬֮����Ը���
            string s = "select * from ʵʱ����� where TM>='2021-05-17 23:00:00.000' and TM<'2021-05-18 00:00:00.000'";
            GetPrecipitation(s);

            //�����Ⱦ��
            DataOperator dataOperator = new DataOperator(axMapControl1.Map);
            IGeoFeatureLayer geoFeatureLayer = dataOperator.GetLayerByName("ShapefileSample") as IGeoFeatureLayer;
            IFeatureRenderer featureRenderer = GetDivideValueRenderer(geoFeatureLayer);

            //����
            geoFeatureLayer.Renderer = featureRenderer;
            axMapControl1.ActiveView.Refresh();
            axTOCControl1.Update();

            MessageBox.Show("���سɹ�");

        }

        private void ��վ�����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //����Զ�����ݿ�
            DataLoad dataLoad = new DataLoad();
            //��Զ�����ݿ��ȡ������վ������shp
            RefreshStands(dataLoad);
            MessageBox.Show("���³ɹ�");
            
        }
    }

}

