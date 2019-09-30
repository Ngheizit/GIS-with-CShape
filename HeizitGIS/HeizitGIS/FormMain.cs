using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeizitGIS
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// 窗体背景透明化
        /// </summary>
        private void Transparency()
        {
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        public FormMain()
        { InitializeComponent(); }


        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Transparency(); // 窗体背景透明化
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("@");
        }
    }
}
