namespace GDAL_Console
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
            this.rtbx_console = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbx_console
            // 
            this.rtbx_console.BackColor = System.Drawing.SystemColors.InfoText;
            this.rtbx_console.Font = new System.Drawing.Font("SimSun", 10F);
            this.rtbx_console.ForeColor = System.Drawing.SystemColors.Info;
            this.rtbx_console.Location = new System.Drawing.Point(-1, -1);
            this.rtbx_console.Name = "rtbx_console";
            this.rtbx_console.ReadOnly = true;
            this.rtbx_console.Size = new System.Drawing.Size(805, 454);
            this.rtbx_console.TabIndex = 0;
            this.rtbx_console.Text = "";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtbx_console);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormMain";
            this.Text = "Console";
            this.Load += new System.EventHandler(this.Console);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbx_console;
    }
}

