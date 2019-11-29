namespace TianDiTuAPI
{
    partial class FormApply
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormApply));
            this.btn_DrawExtent = new System.Windows.Forms.Button();
            this.btn_Zoom2Extent = new System.Windows.Forms.Button();
            this.tbx_OutputCSV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SetOutputCSV = new System.Windows.Forms.Button();
            this.tbx_OutputShp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_SendOutputShp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbx_Xmax = new System.Windows.Forms.TextBox();
            this.tbx_Xmin = new System.Windows.Forms.TextBox();
            this.tbx_Ymax = new System.Windows.Forms.TextBox();
            this.tbx_Ymin = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbx_KeyWord = new System.Windows.Forms.TextBox();
            this.label_KetWord = new System.Windows.Forms.Label();
            this.btn_Run = new System.Windows.Forms.Button();
            this.btn_getTK = new System.Windows.Forms.Button();
            this.tbx_tk = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_DrawExtent
            // 
            this.btn_DrawExtent.Location = new System.Drawing.Point(257, 18);
            this.btn_DrawExtent.Name = "btn_DrawExtent";
            this.btn_DrawExtent.Size = new System.Drawing.Size(77, 23);
            this.btn_DrawExtent.TabIndex = 0;
            this.btn_DrawExtent.Text = "绘制范围";
            this.btn_DrawExtent.UseVisualStyleBackColor = true;
            this.btn_DrawExtent.Click += new System.EventHandler(this.btn_DrawExtent_Click);
            // 
            // btn_Zoom2Extent
            // 
            this.btn_Zoom2Extent.Location = new System.Drawing.Point(257, 72);
            this.btn_Zoom2Extent.Name = "btn_Zoom2Extent";
            this.btn_Zoom2Extent.Size = new System.Drawing.Size(77, 23);
            this.btn_Zoom2Extent.TabIndex = 1;
            this.btn_Zoom2Extent.Text = "缩放至范围";
            this.btn_Zoom2Extent.UseVisualStyleBackColor = true;
            this.btn_Zoom2Extent.Click += new System.EventHandler(this.btn_Zoom2Extent_Click);
            // 
            // tbx_OutputCSV
            // 
            this.tbx_OutputCSV.Location = new System.Drawing.Point(14, 201);
            this.tbx_OutputCSV.Name = "tbx_OutputCSV";
            this.tbx_OutputCSV.ReadOnly = true;
            this.tbx_OutputCSV.Size = new System.Drawing.Size(272, 21);
            this.tbx_OutputCSV.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "搜索结果输出路径（csv）：";
            // 
            // btn_SetOutputCSV
            // 
            this.btn_SetOutputCSV.Location = new System.Drawing.Point(292, 201);
            this.btn_SetOutputCSV.Name = "btn_SetOutputCSV";
            this.btn_SetOutputCSV.Size = new System.Drawing.Size(62, 21);
            this.btn_SetOutputCSV.TabIndex = 4;
            this.btn_SetOutputCSV.Text = "浏览";
            this.btn_SetOutputCSV.UseVisualStyleBackColor = true;
            this.btn_SetOutputCSV.Click += new System.EventHandler(this.btn_SetOutputCSV_Click);
            // 
            // tbx_OutputShp
            // 
            this.tbx_OutputShp.Location = new System.Drawing.Point(14, 255);
            this.tbx_OutputShp.Name = "tbx_OutputShp";
            this.tbx_OutputShp.ReadOnly = true;
            this.tbx_OutputShp.Size = new System.Drawing.Size(272, 21);
            this.tbx_OutputShp.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "生成结果输出路径（shp）：";
            // 
            // btn_SendOutputShp
            // 
            this.btn_SendOutputShp.Location = new System.Drawing.Point(292, 255);
            this.btn_SendOutputShp.Name = "btn_SendOutputShp";
            this.btn_SendOutputShp.Size = new System.Drawing.Size(62, 21);
            this.btn_SendOutputShp.TabIndex = 4;
            this.btn_SendOutputShp.Text = "浏览";
            this.btn_SendOutputShp.UseVisualStyleBackColor = true;
            this.btn_SendOutputShp.Click += new System.EventHandler(this.btn_SendOutputShp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbx_Xmax);
            this.groupBox1.Controls.Add(this.tbx_Xmin);
            this.groupBox1.Controls.Add(this.tbx_Ymax);
            this.groupBox1.Controls.Add(this.tbx_Ymin);
            this.groupBox1.Controls.Add(this.btn_Zoom2Extent);
            this.groupBox1.Controls.Add(this.btn_DrawExtent);
            this.groupBox1.Location = new System.Drawing.Point(14, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 106);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "搜索范围：";
            // 
            // tbx_Xmax
            // 
            this.tbx_Xmax.Location = new System.Drawing.Point(189, 47);
            this.tbx_Xmax.Name = "tbx_Xmax";
            this.tbx_Xmax.ReadOnly = true;
            this.tbx_Xmax.Size = new System.Drawing.Size(90, 21);
            this.tbx_Xmax.TabIndex = 2;
            // 
            // tbx_Xmin
            // 
            this.tbx_Xmin.Location = new System.Drawing.Point(11, 47);
            this.tbx_Xmin.Name = "tbx_Xmin";
            this.tbx_Xmin.ReadOnly = true;
            this.tbx_Xmin.Size = new System.Drawing.Size(90, 21);
            this.tbx_Xmin.TabIndex = 2;
            // 
            // tbx_Ymax
            // 
            this.tbx_Ymax.Location = new System.Drawing.Point(100, 20);
            this.tbx_Ymax.Name = "tbx_Ymax";
            this.tbx_Ymax.ReadOnly = true;
            this.tbx_Ymax.Size = new System.Drawing.Size(90, 21);
            this.tbx_Ymax.TabIndex = 2;
            // 
            // tbx_Ymin
            // 
            this.tbx_Ymin.Location = new System.Drawing.Point(100, 74);
            this.tbx_Ymin.Name = "tbx_Ymin";
            this.tbx_Ymin.ReadOnly = true;
            this.tbx_Ymin.Size = new System.Drawing.Size(90, 21);
            this.tbx_Ymin.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbx_KeyWord);
            this.groupBox2.Controls.Add(this.label_KetWord);
            this.groupBox2.Location = new System.Drawing.Point(14, 300);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 58);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "搜索方式：";
            // 
            // tbx_KeyWord
            // 
            this.tbx_KeyWord.Location = new System.Drawing.Point(113, 23);
            this.tbx_KeyWord.Name = "tbx_KeyWord";
            this.tbx_KeyWord.Size = new System.Drawing.Size(111, 21);
            this.tbx_KeyWord.TabIndex = 1;
            // 
            // label_KetWord
            // 
            this.label_KetWord.AutoSize = true;
            this.label_KetWord.Location = new System.Drawing.Point(54, 28);
            this.label_KetWord.Name = "label_KetWord";
            this.label_KetWord.Size = new System.Drawing.Size(53, 12);
            this.label_KetWord.TabIndex = 2;
            this.label_KetWord.Text = "关键字：";
            // 
            // btn_Run
            // 
            this.btn_Run.Location = new System.Drawing.Point(279, 374);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(75, 23);
            this.btn_Run.TabIndex = 7;
            this.btn_Run.Text = "执行";
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // btn_getTK
            // 
            this.btn_getTK.Location = new System.Drawing.Point(271, 24);
            this.btn_getTK.Name = "btn_getTK";
            this.btn_getTK.Size = new System.Drawing.Size(75, 21);
            this.btn_getTK.TabIndex = 8;
            this.btn_getTK.Text = "申请密钥";
            this.btn_getTK.UseVisualStyleBackColor = true;
            // 
            // tbx_tk
            // 
            this.tbx_tk.Location = new System.Drawing.Point(14, 24);
            this.tbx_tk.Name = "tbx_tk";
            this.tbx_tk.Size = new System.Drawing.Size(251, 21);
            this.tbx_tk.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "天地图API密钥：";
            // 
            // FormApply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 405);
            this.Controls.Add(this.tbx_tk);
            this.Controls.Add(this.btn_getTK);
            this.Controls.Add(this.btn_Run);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_SendOutputShp);
            this.Controls.Add(this.btn_SetOutputCSV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_OutputShp);
            this.Controls.Add(this.tbx_OutputCSV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormApply";
            this.Text = "天地图POI提取平台 - 操作层";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormApply_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_DrawExtent;
        private System.Windows.Forms.Button btn_Zoom2Extent;
        private System.Windows.Forms.TextBox tbx_OutputCSV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_SetOutputCSV;
        private System.Windows.Forms.TextBox tbx_OutputShp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_SendOutputShp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbx_Xmax;
        private System.Windows.Forms.TextBox tbx_Xmin;
        private System.Windows.Forms.TextBox tbx_Ymax;
        private System.Windows.Forms.TextBox tbx_Ymin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbx_KeyWord;
        private System.Windows.Forms.Label label_KetWord;
        private System.Windows.Forms.Button btn_Run;
        private System.Windows.Forms.Button btn_getTK;
        private System.Windows.Forms.TextBox tbx_tk;
        private System.Windows.Forms.Label label2;
    }
}