using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;

namespace TianDiTuAPI
{
    public partial class FormMain : Form
    {
        private IMapControl2 m_pMapC2;
        private IMapDocument m_pMapDoc;
        private FormApply f_apply;

        public FormMain()
        {
            InitializeComponent();
            this.m_pMapC2 = axMapControl1.Object as IMapControl2;
            this.m_pMapDoc = new MapDocumentClass();
            this.f_apply = new FormApply();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            AeUtils.SetMapControl(m_pMapC2);
            AeUtils.SetMapDocment(m_pMapDoc);
            AeUtils.LoadMxd(@"./Map.mxd");
            f_apply.Show();
        }

        private void btn_Zoom_Click(object sender, EventArgs e)
        {
            if ((Button)sender == btn_ZoomIn)
                AeUtils.ZoomIn();
            else
                AeUtils.ZoomOut();
        }

        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 4)
            {
                AeUtils.Pan();
            }
            if (f_apply.IsDraw && e.button == 1)
            {
                IEnvelope pEnv = AeUtils.TrackRectangle();
                IRgbColor pFillColor = AeUtils.CreateRgbColor(0);
                IRgbColor pOutlineColor = AeUtils.CreateRgbColor(255, 0, 0);
                ISimpleFillSymbol pSymbol = AeUtils.CreateSimpleFillSymbol(pFillColor, pOutlineColor, 2);
                AeUtils.DrawExtent(pEnv, pSymbol);
                f_apply.IsDraw = false;
                f_apply.SetParams_Extent(pEnv);
            }
        }

        private void btn_ZoomToHome_Click(object sender, EventArgs e)
        {
            AeUtils.ZoomToHome();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            AeUtils.UpdateHome();
        }

        private void btn_TocControl_Click(object sender, EventArgs e)
        {
            axTOCControl1.Visible = !axTOCControl1.Visible;
        }



    }
}
