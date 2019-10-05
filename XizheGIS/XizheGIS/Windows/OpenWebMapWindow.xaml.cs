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
using System.Windows.Shapes;


using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Portal;
namespace XizheGIS.Windows
{
    /// <summary>
    /// Interaction logic for OpenWebMapWindow.xaml
    /// </summary>
    public partial class OpenWebMapWindow : Window
    {
        public OpenWebMapWindow()
        {
            InitializeComponent();
            tbx_webmapUrl.Text = "https://www.arcgis.com/home/webmap/viewer.html?webmap=69fdcd8e40734712aaec34194d4b988c";
            tbx_webmapId.Text = "69fdcd8e40734712aaec34194d4b988c";
        }

        private async void Btn_loacWebmap_Click(object sender, RoutedEventArgs e)
        {
            if((Button)sender == btn_loacWebmap)
            {
                try {
                    var webMap = await Map.LoadFromUriAsync(new Uri(tbx_webmapUrl.Text));
                    axMapView.Map = webMap;
                }
                catch (Exception error)
                { MessageBox.Show(error.ToString()); }
                return;
            }
            if((Button)sender == btn_loacWebmap2)
            {
                try {
                    ArcGISPortal arcGISPortal = await ArcGISPortal.CreateAsync();
                    var portalItem = await PortalItem.CreateAsync(arcGISPortal, tbx_webmapId.Text);
                    var map = new Map(portalItem);
                    axMapView.Map = map;
                }
                catch (Exception error)
                { MessageBox.Show(error.ToString()); }
                return;
            }
        }
    }
}
