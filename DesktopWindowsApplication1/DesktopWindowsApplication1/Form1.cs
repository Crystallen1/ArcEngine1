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
            //创建空测站点数据shp 
            //首先创建含基本空间信息和OID字段的shp
            DataOperator dataOperator = new DataOperator(axMapControl1.Map);
            IFeatureClass featureClass = dataOperator.CreateShapefile("D:\\", "ShapefileWorkspace", "ShapefileSample");
            if (featureClass == null)
            {
                MessageBox.Show("创建shape文件失败");
                return;
            }

            //给创建的shp添加站名等字段
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

            //连接数据库，添加所有站点数据

            SqlDataReader stands = dataLoad.ExecuteSQL("select*from 站点属性表");
            while (stands.Read())
            {

                IFeature feature = featureClass.CreateFeature();
                string stcd = stands["STCD"].ToString().Trim();
                string stnm = stands["STNM"].ToString().Trim();
                double lat = Convert.ToDouble(stands["LGTD"].ToString().Trim());
                double lon = Convert.ToDouble(stands["LTTD"].ToString().Trim());
                IPoint point = new ESRI.ArcGIS.Geometry.Point();
                //添加形状（含坐标信息）
                point.PutCoords(lat, lon);
                feature.Shape = point;
                //获取各属性的index后插入记录属性值
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
            //加载底图（浅灰色）
            IFeatureClass basemapFeature = dataOperator.GetFeatureClass("D:\\1\\GIS\\Shape", "行政区域.shp");
            ISimpleRenderer simpleRenderer = new SimpleRenderer();
            ISimpleFillSymbol simpleFillSymbol = new SimpleFillSymbol();
            simpleFillSymbol.Style = esriSimpleFillStyle.esriSFSSolid;
            IRgbColor rgbColor = new RgbColor();
            rgbColor.Red = 245;
            rgbColor.Green = 245;
            rgbColor.Blue = 245;
            simpleFillSymbol.Color = rgbColor;
            simpleRenderer.Symbol = simpleFillSymbol as ISymbol;
            bool bRes = dataOperator.AddFeatureClassToMap(basemapFeature, "底图", simpleRenderer as IFeatureRenderer);
            axMapControl1.Refresh();
            //初次使用时还没有建下面这个站点的文件，需要先更新站点建立该文件，即运行下面注释掉的内容
            //连接远程数据库
            DataLoad dataLoad = new DataLoad();
            //从远程数据库读取并创建站点数据shp
            RefreshStands(dataLoad);
            axMapControl1.AddShapeFile("D:\\" + "ShapefileWorkspace", "ShapefileSample");
            axMapControl1.Refresh();
        }



        public void CreatBookMark(string sBookMarkName)
        {
            //保存当前地区的范围
            IAOIBookmark aoiBookmark = new AOIBookmarkClass();
            if (aoiBookmark != null)
            {
                aoiBookmark.Location = axMapControl1.ActiveView.Extent;
                aoiBookmark.Name = sBookMarkName;
            }
            //向地图中加入书签
            IMapBookmarks bookmarks = axMapControl1.Map as IMapBookmarks;
            if (bookmarks != null)
            {
                bookmarks.AddBookmark(aoiBookmark);
            }
            //将新建书签加入组合框
            comboBox1.Items.Add(aoiBookmark.Name);
        }

        private void 创建书签ToolStripMenuItem_Click(object sender, EventArgs e)
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
            //定义一循环游标
            IFeatureCursor featureCursor = geoFeatureLayer.FeatureClass.Search(null, false);
            IFeature feature;
            if (featureCursor != null)
            {

                //查找降水字段、站点编号字段的索引号,arc自动把precipitation变为precipitat
                int fieldIndexp = geoFeatureLayer.FeatureClass.Fields.FindField("precipitat");
                int fieldIndexs = geoFeatureLayer.FeatureClass.Fields.FindField("STCD");
                //遍历
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
                //首先获得符号的类型
                ISymbol symbol = MapComposer.GetSymbolFromLayer(layer);
                int classCount = 5;  //等级数
                //实例化
                //BasicTableHistogramClass 采用表对象输入数据的结构（如自然断点、分位数）生成直方图
                ITableHistogram tableHistogram = new BasicTableHistogram() as ITableHistogram;
                tableHistogram.Table = table;
                tableHistogram.Field = "precipitat";

                IBasicHistogram basicHistogram = tableHistogram as IBasicHistogram;
                //先统计每个值出现的次数、输出结果为 vakues,frequencys
                object values;
                object frequencys;
                basicHistogram.GetHistogram(out values, out frequencys);
                //IClassifyGEN实现了对所有数据对象的分类(DefineInterval、EqualInterval、NatureBreaks、Quantile、StandardDeviation)
                //此处创建一平均分级对象，用统计结果进行分级
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

                //定义一颜色枚举变量，通过函数获取色带
                IEnumColors enumColors = Rendering.makeAlgorithmicColorRamp(Rendering.makeRGBColor(255, 235, 214), Rendering.makeRGBColor(196, 10, 10), classCount).Colors;
                IColor color;
                IClassBreaksRenderer classBreaksRenderer = new ClassBreaksRenderer();
                classBreaksRenderer.BreakCount = classCount; //设置分级数
                classBreaksRenderer.Field = "precipitat";
                classBreaksRenderer.SortClassesAscending = true; //升序显示

                //给所有等级附上渲染颜色
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

        private void 小时ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //更新站点shp的雨量数据字段
            //此处暂时认为数据库里最后的一小时，即5.23晚十一点为当前时间，之后可以更改
            string s = "select * from 实时雨情表 where TM>='2021-05-17 23:00:00.000' and TM<'2021-05-18 00:00:00.000'";
            GetPrecipitation(s);

            //获得渲染器
            DataOperator dataOperator = new DataOperator(axMapControl1.Map);
            IGeoFeatureLayer geoFeatureLayer = dataOperator.GetLayerByName("ShapefileSample") as IGeoFeatureLayer;
            IFeatureRenderer featureRenderer = GetDivideValueRenderer(geoFeatureLayer);

            //更新
            geoFeatureLayer.Renderer = featureRenderer;
            axMapControl1.ActiveView.Refresh();
            axTOCControl1.Update();

            MessageBox.Show("加载成功");

        }

        private void 测站点更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //连接远程数据库
            DataLoad dataLoad = new DataLoad();
            //从远程数据库读取并创建站点数据shp
            RefreshStands(dataLoad);
            MessageBox.Show("更新成功");
            
        }
    }

}

