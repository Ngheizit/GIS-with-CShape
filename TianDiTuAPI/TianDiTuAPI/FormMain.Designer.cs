namespace TianDiTuAPI
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.btn_TocControl = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_ZoomToHome = new System.Windows.Forms.Button();
            this.btn_ZoomOut = new System.Windows.Forms.Button();
            this.btn_ZoomIn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(100, 145);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 0;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axMapControl1.Location = new System.Drawing.Point(0, 0);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(1007, 526);
            this.axMapControl1.TabIndex = 1;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axTOCControl1.Location = new System.Drawing.Point(766, 0);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(241, 526);
            this.axTOCControl1.TabIndex = 2;
            this.axTOCControl1.Visible = false;
            // 
            // btn_TocControl
            // 
            this.btn_TocControl.BackColor = System.Drawing.Color.White;
            this.btn_TocControl.BackgroundImage = global::TianDiTuAPI.Properties.Resources.图层;
            this.btn_TocControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_TocControl.Location = new System.Drawing.Point(11, 123);
            this.btn_TocControl.Name = "btn_TocControl";
            this.btn_TocControl.Size = new System.Drawing.Size(25, 25);
            this.btn_TocControl.TabIndex = 3;
            this.btn_TocControl.UseVisualStyleBackColor = false;
            this.btn_TocControl.Click += new System.EventHandler(this.btn_TocControl_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.White;
            this.btn_save.BackgroundImage = global::TianDiTuAPI.Properties.Resources.save;
            this.btn_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_save.Location = new System.Drawing.Point(11, 92);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(25, 25);
            this.btn_save.TabIndex = 3;
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_ZoomToHome
            // 
            this.btn_ZoomToHome.BackColor = System.Drawing.Color.White;
            this.btn_ZoomToHome.BackgroundImage = global::TianDiTuAPI.Properties.Resources.home;
            this.btn_ZoomToHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ZoomToHome.Location = new System.Drawing.Point(11, 67);
            this.btn_ZoomToHome.Name = "btn_ZoomToHome";
            this.btn_ZoomToHome.Size = new System.Drawing.Size(25, 25);
            this.btn_ZoomToHome.TabIndex = 3;
            this.btn_ZoomToHome.UseVisualStyleBackColor = false;
            this.btn_ZoomToHome.Click += new System.EventHandler(this.btn_ZoomToHome_Click);
            // 
            // btn_ZoomOut
            // 
            this.btn_ZoomOut.BackColor = System.Drawing.Color.White;
            this.btn_ZoomOut.BackgroundImage = global::TianDiTuAPI.Properties.Resources.ZoomOut;
            this.btn_ZoomOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ZoomOut.Location = new System.Drawing.Point(11, 36);
            this.btn_ZoomOut.Name = "btn_ZoomOut";
            this.btn_ZoomOut.Size = new System.Drawing.Size(25, 25);
            this.btn_ZoomOut.TabIndex = 3;
            this.btn_ZoomOut.UseVisualStyleBackColor = false;
            this.btn_ZoomOut.Click += new System.EventHandler(this.btn_Zoom_Click);
            // 
            // btn_ZoomIn
            // 
            this.btn_ZoomIn.BackColor = System.Drawing.Color.White;
            this.btn_ZoomIn.BackgroundImage = global::TianDiTuAPI.Properties.Resources.ZoomIn;
            this.btn_ZoomIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ZoomIn.Location = new System.Drawing.Point(11, 11);
            this.btn_ZoomIn.Name = "btn_ZoomIn";
            this.btn_ZoomIn.Size = new System.Drawing.Size(25, 25);
            this.btn_ZoomIn.TabIndex = 3;
            this.btn_ZoomIn.UseVisualStyleBackColor = false;
            this.btn_ZoomIn.Click += new System.EventHandler(this.btn_Zoom_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 526);
            this.Controls.Add(this.btn_TocControl);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_ZoomToHome);
            this.Controls.Add(this.btn_ZoomOut);
            this.Controls.Add(this.btn_ZoomIn);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.axLicenseControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "天地图POI提取平台 - 视图层";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private System.Windows.Forms.Button btn_ZoomIn;
        private System.Windows.Forms.Button btn_ZoomOut;
        private System.Windows.Forms.Button btn_ZoomToHome;
        private System.Windows.Forms.Button btn_TocControl;
        private System.Windows.Forms.Button btn_save;
    }
}

