namespace Pic2icon
{
    partial class Form1
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
            this.tbx_picture = new System.Windows.Forms.TextBox();
            this.btn_picture = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_result = new System.Windows.Forms.TextBox();
            this.btn_result = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.num_width = new System.Windows.Forms.NumericUpDown();
            this.btn_run = new System.Windows.Forms.Button();
            this.num_height = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.num_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_height)).BeginInit();
            this.SuspendLayout();
            // 
            // tbx_picture
            // 
            this.tbx_picture.Location = new System.Drawing.Point(85, 12);
            this.tbx_picture.Name = "tbx_picture";
            this.tbx_picture.ReadOnly = true;
            this.tbx_picture.Size = new System.Drawing.Size(151, 21);
            this.tbx_picture.TabIndex = 0;
            // 
            // btn_picture
            // 
            this.btn_picture.Location = new System.Drawing.Point(242, 12);
            this.btn_picture.Name = "btn_picture";
            this.btn_picture.Size = new System.Drawing.Size(52, 21);
            this.btn_picture.TabIndex = 1;
            this.btn_picture.Text = "浏览";
            this.btn_picture.UseVisualStyleBackColor = true;
            this.btn_picture.Click += new System.EventHandler(this.btn_picture_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "导入图片：";
            // 
            // tbx_result
            // 
            this.tbx_result.Location = new System.Drawing.Point(85, 39);
            this.tbx_result.Name = "tbx_result";
            this.tbx_result.ReadOnly = true;
            this.tbx_result.Size = new System.Drawing.Size(151, 21);
            this.tbx_result.TabIndex = 0;
            // 
            // btn_result
            // 
            this.btn_result.Location = new System.Drawing.Point(242, 39);
            this.btn_result.Name = "btn_result";
            this.btn_result.Size = new System.Drawing.Size(52, 21);
            this.btn_result.TabIndex = 1;
            this.btn_result.Text = "浏览";
            this.btn_result.UseVisualStyleBackColor = true;
            this.btn_result.Click += new System.EventHandler(this.btn_result_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "输出路径：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Icon尺寸：";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(306, 100);
            this.shapeContainer1.TabIndex = 5;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape2
            // 
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 146;
            this.lineShape2.X2 = 154;
            this.lineShape2.Y1 = 76;
            this.lineShape2.Y2 = 84;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 146;
            this.lineShape1.X2 = 154;
            this.lineShape1.Y1 = 84;
            this.lineShape1.Y2 = 76;
            // 
            // num_width
            // 
            this.num_width.Location = new System.Drawing.Point(86, 70);
            this.num_width.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.num_width.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.num_width.Name = "num_width";
            this.num_width.Size = new System.Drawing.Size(53, 21);
            this.num_width.TabIndex = 6;
            this.num_width.Tag = "";
            this.num_width.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.num_width.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(222, 70);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(72, 21);
            this.btn_run.TabIndex = 1;
            this.btn_run.Text = "转换";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // num_height
            // 
            this.num_height.Location = new System.Drawing.Point(163, 70);
            this.num_height.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.num_height.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.num_height.Name = "num_height";
            this.num_height.Size = new System.Drawing.Size(53, 21);
            this.num_height.TabIndex = 6;
            this.num_height.Tag = "";
            this.num_height.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.num_height.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(306, 100);
            this.Controls.Add(this.num_height);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.num_width);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_result);
            this.Controls.Add(this.btn_picture);
            this.Controls.Add(this.tbx_result);
            this.Controls.Add(this.tbx_picture);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "图片转Icon图标";
            ((System.ComponentModel.ISupportInitialize)(this.num_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_height)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_picture;
        private System.Windows.Forms.Button btn_picture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_result;
        private System.Windows.Forms.Button btn_result;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private System.Windows.Forms.NumericUpDown num_width;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.NumericUpDown num_height;
    }
}

