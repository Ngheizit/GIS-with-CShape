using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace NgheizitGDAL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GdalConfiguration.ConfigureGdal();
            GdalConfiguration.ConfigureOgr();
            OSGeo.GDAL.Gdal.AllRegister();

            string strInfomation = GDAL_readVector.GetVectorInfo(@"D:\githubprogram\PythonLearning\GDAL_Arcpy\GeoData\China\Cities.shp");
            richTextBox1.Text = strInfomation;
        }
    }
}
