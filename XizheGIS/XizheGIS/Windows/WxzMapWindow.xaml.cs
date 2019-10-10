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
    /// Interaction logic for WxzMapWindow.xaml
    /// </summary>
    public partial class WxzMapWindow : Window
    {
        public WxzMapWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 初始化地图
            this.axMapView.Map = new Map(Basemap.CreateOpenStreetMap());

            // GetFeatureLayer("https://services9.arcgis.com/8vu5jgpRPi7NCKmE/ArcGIS/rest/services/中国省级行政中心/FeatureServer/0");

        }

        public async void GetFeatureLayer(string url)
        {
            FeatureLayer pFeatureLayer = new FeatureLayer(new Uri(url));
            await pFeatureLayer.LoadAsync();
            this.axMapView.Map.OperationalLayers.Add(pFeatureLayer);
            this.axMapView.Map.InitialViewpoint = new Viewpoint(pFeatureLayer.FullExtent);
        }
        public async void GetFeatureLayerById(string portalItemId)
        {
            ArcGISPortal portal = await ArcGISPortal.CreateAsync();
            PortalItem portalItem = await PortalItem.CreateAsync(portal, portalItemId);
            FeatureLayer pFeatureLayer = new FeatureLayer(portalItem, 0);
            await pFeatureLayer.LoadAsync();
            this.axMapView.Map.OperationalLayers.Add(pFeatureLayer);
            this.axMapView.Map.InitialViewpoint = new Viewpoint(pFeatureLayer.FullExtent);
        }


        private void Tbx_cmd_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                string cmd = tbx_cmd.Text;
                string[] cmds = cmd.Split(' ');
                switch (cmds[0])
                {
                    case "gfl":
                        if (cmds[1] == "id") GetFeatureLayerById(cmds[2]);
                        else GetFeatureLayer(cmds[1]);
                        break;
                }
            }
        }
    }
}
