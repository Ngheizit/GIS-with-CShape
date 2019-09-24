namespace GDAL_CShape
{
    partial class FormMain
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
            this.treeView_Dir = new System.Windows.Forms.TreeView();
            this.tbx_showPath = new System.Windows.Forms.TextBox();
            this.rtbx_spactialRef = new System.Windows.Forms.RichTextBox();
            this.pictureBox_shp = new System.Windows.Forms.PictureBox();
            this.rtbx_test = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.footlabel_xy = new System.Windows.Forms.ToolStripStatusLabel();
            this.rtbx_loca = new System.Windows.Forms.RichTextBox();
            this.btn_openiInWindow = new System.Windows.Forms.Button();
            this.btn_shp2zip = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_shp)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView_Dir
            // 
            this.treeView_Dir.Location = new System.Drawing.Point(0, -1);
            this.treeView_Dir.Name = "treeView_Dir";
            this.treeView_Dir.Size = new System.Drawing.Size(200, 459);
            this.treeView_Dir.TabIndex = 0;
            this.treeView_Dir.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView_Dir_BeforeExpand);
            this.treeView_Dir.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_Dir_AfterExpand);
            this.treeView_Dir.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_Dir_AfterSelect);
            // 
            // tbx_showPath
            // 
            this.tbx_showPath.Location = new System.Drawing.Point(199, -1);
            this.tbx_showPath.Name = "tbx_showPath";
            this.tbx_showPath.ReadOnly = true;
            this.tbx_showPath.Size = new System.Drawing.Size(674, 21);
            this.tbx_showPath.TabIndex = 2;
            // 
            // rtbx_spactialRef
            // 
            this.rtbx_spactialRef.Location = new System.Drawing.Point(666, 267);
            this.rtbx_spactialRef.Name = "rtbx_spactialRef";
            this.rtbx_spactialRef.Size = new System.Drawing.Size(296, 191);
            this.rtbx_spactialRef.TabIndex = 3;
            this.rtbx_spactialRef.Text = "";
            // 
            // pictureBox_shp
            // 
            this.pictureBox_shp.BackColor = System.Drawing.Color.White;
            this.pictureBox_shp.Location = new System.Drawing.Point(206, 26);
            this.pictureBox_shp.Name = "pictureBox_shp";
            this.pictureBox_shp.Size = new System.Drawing.Size(454, 429);
            this.pictureBox_shp.TabIndex = 7;
            this.pictureBox_shp.TabStop = false;
            this.pictureBox_shp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_shp_MouseMove);
            // 
            // rtbx_test
            // 
            this.rtbx_test.Location = new System.Drawing.Point(666, 26);
            this.rtbx_test.Name = "rtbx_test";
            this.rtbx_test.Size = new System.Drawing.Size(108, 27);
            this.rtbx_test.TabIndex = 8;
            this.rtbx_test.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.footlabel_xy});
            this.statusStrip1.Location = new System.Drawing.Point(0, 458);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(974, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // footlabel_xy
            // 
            this.footlabel_xy.Name = "footlabel_xy";
            this.footlabel_xy.Size = new System.Drawing.Size(22, 17);
            this.footlabel_xy.Text = "     ";
            // 
            // rtbx_loca
            // 
            this.rtbx_loca.Location = new System.Drawing.Point(666, 161);
            this.rtbx_loca.Name = "rtbx_loca";
            this.rtbx_loca.Size = new System.Drawing.Size(296, 100);
            this.rtbx_loca.TabIndex = 8;
            this.rtbx_loca.Text = "";
            // 
            // btn_openiInWindow
            // 
            this.btn_openiInWindow.Location = new System.Drawing.Point(875, -1);
            this.btn_openiInWindow.Name = "btn_openiInWindow";
            this.btn_openiInWindow.Size = new System.Drawing.Size(99, 21);
            this.btn_openiInWindow.TabIndex = 10;
            this.btn_openiInWindow.Text = "open in folder";
            this.btn_openiInWindow.UseVisualStyleBackColor = true;
            this.btn_openiInWindow.Click += new System.EventHandler(this.Btn_openiInWindow_Click);
            // 
            // btn_shp2zip
            // 
            this.btn_shp2zip.Location = new System.Drawing.Point(863, 25);
            this.btn_shp2zip.Name = "btn_shp2zip";
            this.btn_shp2zip.Size = new System.Drawing.Size(111, 21);
            this.btn_shp2zip.TabIndex = 11;
            this.btn_shp2zip.Text = "shapefile to zip";
            this.btn_shp2zip.UseVisualStyleBackColor = true;
            this.btn_shp2zip.Click += new System.EventHandler(this.Btn_shp2zip_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 480);
            this.Controls.Add(this.btn_shp2zip);
            this.Controls.Add(this.btn_openiInWindow);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.rtbx_loca);
            this.Controls.Add(this.rtbx_test);
            this.Controls.Add(this.pictureBox_shp);
            this.Controls.Add(this.rtbx_spactialRef);
            this.Controls.Add(this.tbx_showPath);
            this.Controls.Add(this.treeView_Dir);
            this.Name = "FormMain";
            this.Text = "GIS Catalog";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_shp)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_Dir;
        private System.Windows.Forms.TextBox tbx_showPath;
        private System.Windows.Forms.RichTextBox rtbx_spactialRef;
        private System.Windows.Forms.PictureBox pictureBox_shp;
        private System.Windows.Forms.RichTextBox rtbx_test;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel footlabel_xy;
        private System.Windows.Forms.RichTextBox rtbx_loca;
        private System.Windows.Forms.Button btn_openiInWindow;
        private System.Windows.Forms.Button btn_shp2zip;
    }
}

