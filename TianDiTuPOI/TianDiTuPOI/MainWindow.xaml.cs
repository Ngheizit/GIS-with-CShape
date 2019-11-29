using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;

namespace TianDiTuPOI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private AxLicenseControl licenseControl;
        private AxMapControl mapControl;
        private DoWindow dowindow;


        private IMapControl2 m_pMapC2;
        private IMapDocument m_pMapDoc;

        public MainWindow()
        {
            InitializeComponent();
            CreateEngineControls();
        }

        private void CreateEngineControls()
        {
            licenseControl = new AxLicenseControl();
            licenseHost.Child = licenseControl;

            mapControl = new AxMapControl();
            mapHost.Child = mapControl;
        }

        private void SetControlsProperty()
        {
            mapControl.OnMouseDown += new IMapControlEvents2_Ax_OnMouseDownEventHandler(mapControl_OnMouseMove);
        }

        private void mapControl_OnMouseMove(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 4)
            {
                m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerPanning;
                m_pMapC2.Pan();
                m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;
            }
            if (e.button == 1)
            {
                if (dowindow.IsDraw)
                {
                    m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
                    IEnvelope pEnv = m_pMapC2.TrackRectangle();
                    AeUtils.DrawEnvelope(pEnv);
                    m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetControlsProperty();
            m_pMapC2 = mapControl.GetOcx() as IMapControl2;
            m_pMapDoc = new MapDocumentClass();

            AeUtils.SetMapControl(m_pMapC2);
            LoadMxd();

            dowindow = new DoWindow(m_pMapC2);
            dowindow.Show();
        }

        private void LoadMxd(string mxdPath = @"./Map.mxd")
        {
            if (m_pMapC2.CheckMxFile(mxdPath))
            {
                m_pMapDoc.Open(mxdPath);
                m_pMapC2.Map = m_pMapDoc.Map[0];
            }
        }
    }
}
