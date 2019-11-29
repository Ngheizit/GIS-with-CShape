using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.Geometry;

namespace TianDiTuAPI
{
    public partial class FormApply : Form
    {
        private bool _isDraw;
        public bool IsDraw
        {
            get { return this._isDraw; }
            set { this._isDraw = value; }
        }
        private string _params_Extent;
        private IEnvelope _extent;

        public FormApply()
        {
            InitializeComponent();
            this._isDraw = false;
        }

        private void btn_DrawExtent_Click(object sender, EventArgs e)
        {
            _isDraw = !_isDraw;
        }

        public void SetParams_Extent(IEnvelope envelope)
        {

            double Xmax = envelope.XMax,
                   Xmin = envelope.XMin,
                   Ymax = envelope.YMax,
                   Ymin = envelope.YMin;

            tbx_Xmax.Text = Xmax.ToString();
            tbx_Xmin.Text = Xmin.ToString();
            tbx_Ymax.Text = Ymax.ToString();
            tbx_Ymin.Text = Ymin.ToString();
            _params_Extent = String.Format("{0},{1},{2},{3}", Xmin, Ymin, Xmax, Ymax);
            _extent = envelope;
        }

        private void FormApply_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否退出程序", "退出程序", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            Application.ExitThread();
        }

        private void btn_Zoom2Extent_Click(object sender, EventArgs e)
        {
            AeUtils.ZoomToEnvlope(_extent);
        }

        private void btn_SetOutputCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfg = new SaveFileDialog() { 
                Title = "csv结果保存位置",
                Filter = "CSV |*.csv"
            };
            if (sfg.ShowDialog() == DialogResult.OK)
            {
                tbx_OutputCSV.Text = sfg.FileName;
                tbx_OutputShp.Text = sfg.FileName.Split('.')[0] + ".shp";
            }
        }

        private void btn_SendOutputShp_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfg = new SaveFileDialog()
            {
                Title = "shp结果保存位置",
                Filter = "Shapefile |*.shp"
            };
            if (sfg.ShowDialog() == DialogResult.OK)
            {
                tbx_OutputShp.Text = sfg.FileName;
            }
        }

        private void btn_Run_Click(object sender, EventArgs e)
        {
            string tk = tbx_tk.Text;
            string keyWord = tbx_KeyWord.Text;
            string mapBound = _params_Extent;
            string queryType = "10";
            string outCSV = tbx_OutputCSV.Text;
            string py = Application.StartupPath + @"\TianDiTuAPI.py";

            FormRuntime rtime = new FormRuntime(2);
            rtime.Show();

            rtime.Go();
            PyUtils.RunPy(py, "", new string[]{
                tk, keyWord, mapBound, queryType, outCSV
            });
            rtime.Go();

            AeUtils.CreateShpFromCSV(outCSV, tbx_OutputShp.Text);
            rtime.Ok();
        }


    }
}
