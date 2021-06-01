namespace DesktopWindowsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测站点更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.当前雨量数据更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.按小时分类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.小时ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.小时ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.小时ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.小时ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.条件查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.书签ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建书签ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更新ToolStripMenuItem,
            this.按小时分类ToolStripMenuItem,
            this.条件查询ToolStripMenuItem,
            this.书签ToolStripMenuItem,
            this.统计ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1118, 39);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 更新ToolStripMenuItem
            // 
            this.更新ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.测站点更新ToolStripMenuItem,
            this.当前雨量数据更新ToolStripMenuItem});
            this.更新ToolStripMenuItem.Name = "更新ToolStripMenuItem";
            this.更新ToolStripMenuItem.Size = new System.Drawing.Size(74, 35);
            this.更新ToolStripMenuItem.Text = "更新";
            // 
            // 测站点更新ToolStripMenuItem
            // 
            this.测站点更新ToolStripMenuItem.Name = "测站点更新ToolStripMenuItem";
            this.测站点更新ToolStripMenuItem.Size = new System.Drawing.Size(280, 36);
            this.测站点更新ToolStripMenuItem.Text = "测站点更新";
            this.测站点更新ToolStripMenuItem.Click += new System.EventHandler(this.测站点更新ToolStripMenuItem_Click);
            // 
            // 当前雨量数据更新ToolStripMenuItem
            // 
            this.当前雨量数据更新ToolStripMenuItem.Name = "当前雨量数据更新ToolStripMenuItem";
            this.当前雨量数据更新ToolStripMenuItem.Size = new System.Drawing.Size(280, 36);
            this.当前雨量数据更新ToolStripMenuItem.Text = "当前雨量数据更新";
            // 
            // 按小时分类ToolStripMenuItem
            // 
            this.按小时分类ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.小时ToolStripMenuItem,
            this.小时ToolStripMenuItem1,
            this.小时ToolStripMenuItem2,
            this.小时ToolStripMenuItem3});
            this.按小时分类ToolStripMenuItem.Name = "按小时分类ToolStripMenuItem";
            this.按小时分类ToolStripMenuItem.Size = new System.Drawing.Size(146, 35);
            this.按小时分类ToolStripMenuItem.Text = "按时间查询";
            // 
            // 小时ToolStripMenuItem
            // 
            this.小时ToolStripMenuItem.Name = "小时ToolStripMenuItem";
            this.小时ToolStripMenuItem.Size = new System.Drawing.Size(164, 36);
            this.小时ToolStripMenuItem.Text = "1小时";
            this.小时ToolStripMenuItem.Click += new System.EventHandler(this.小时ToolStripMenuItem_Click);
            // 
            // 小时ToolStripMenuItem1
            // 
            this.小时ToolStripMenuItem1.Name = "小时ToolStripMenuItem1";
            this.小时ToolStripMenuItem1.Size = new System.Drawing.Size(164, 36);
            this.小时ToolStripMenuItem1.Text = "3小时";
            // 
            // 小时ToolStripMenuItem2
            // 
            this.小时ToolStripMenuItem2.Name = "小时ToolStripMenuItem2";
            this.小时ToolStripMenuItem2.Size = new System.Drawing.Size(164, 36);
            this.小时ToolStripMenuItem2.Text = "6小时";
            // 
            // 小时ToolStripMenuItem3
            // 
            this.小时ToolStripMenuItem3.Name = "小时ToolStripMenuItem3";
            this.小时ToolStripMenuItem3.Size = new System.Drawing.Size(164, 36);
            this.小时ToolStripMenuItem3.Text = "24小时";
            // 
            // 条件查询ToolStripMenuItem
            // 
            this.条件查询ToolStripMenuItem.Name = "条件查询ToolStripMenuItem";
            this.条件查询ToolStripMenuItem.Size = new System.Drawing.Size(122, 35);
            this.条件查询ToolStripMenuItem.Text = "条件查询";
            // 
            // 书签ToolStripMenuItem
            // 
            this.书签ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.创建书签ToolStripMenuItem});
            this.书签ToolStripMenuItem.Name = "书签ToolStripMenuItem";
            this.书签ToolStripMenuItem.Size = new System.Drawing.Size(74, 35);
            this.书签ToolStripMenuItem.Text = "书签";
            // 
            // 创建书签ToolStripMenuItem
            // 
            this.创建书签ToolStripMenuItem.Name = "创建书签ToolStripMenuItem";
            this.创建书签ToolStripMenuItem.Size = new System.Drawing.Size(184, 36);
            this.创建书签ToolStripMenuItem.Text = "创建书签";
            this.创建书签ToolStripMenuItem.Click += new System.EventHandler(this.创建书签ToolStripMenuItem_Click);
            // 
            // 统计ToolStripMenuItem
            // 
            this.统计ToolStripMenuItem.Name = "统计ToolStripMenuItem";
            this.统计ToolStripMenuItem.Size = new System.Drawing.Size(74, 35);
            this.统计ToolStripMenuItem.Text = "统计";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 39);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.axToolbarControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1118, 668);
            this.splitContainer1.SplitterDistance = 42;
            this.splitContainer1.TabIndex = 1;
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 0);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(1118, 28);
            this.axToolbarControl1.TabIndex = 0;
            this.axToolbarControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IToolbarControlEvents_Ax_OnMouseDownEventHandler(this.axToolbarControl1_OnMouseDown);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.axTOCControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.axLicenseControl1);
            this.splitContainer2.Panel2.Controls.Add(this.axMapControl1);
            this.splitContainer2.Size = new System.Drawing.Size(1118, 622);
            this.splitContainer2.SplitterDistance = 284;
            this.splitContainer2.TabIndex = 0;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl1.Location = new System.Drawing.Point(0, 0);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(284, 622);
            this.axTOCControl1.TabIndex = 0;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(484, 506);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 1;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(0, 0);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(830, 622);
            this.axMapControl1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(997, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 32);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 707);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 更新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测站点更新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 当前雨量数据更新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 按小时分类ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 小时ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 小时ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 条件查询ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem 书签ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建书签ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 小时ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 小时ToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 统计ToolStripMenuItem;

    }
}

