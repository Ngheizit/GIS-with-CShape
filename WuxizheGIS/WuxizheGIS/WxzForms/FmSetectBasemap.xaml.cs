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

namespace WuxizheGIS.WxzForms
{
    /// <summary>
    /// FmSetectBasemap.xaml 的交互逻辑
    /// </summary>
    public partial class FmSetectBasemap : Window
    {
        public FmSetectBasemap()
        {
            InitializeComponent();
        }

        private Basemap[] m_pBasemaps = new Basemap[]
        {
            Basemap.CreateImagery(),
            Basemap.CreateImageryWithLabels(),
            Basemap.CreateStreets(),
            Basemap.CreateTopographic(),
            Basemap.CreateTerrainWithLabels(),
            Basemap.CreateLightGrayCanvas(),
            Basemap.CreateNationalGeographic(),
            Basemap.CreateOceans(),
            Basemap.CreateOpenStreetMap(),
            Basemap.CreateImageryWithLabelsVector(),
            Basemap.CreateStreetsVector(),
            Basemap.CreateTopographicVector(),
            Basemap.CreateTerrainWithLabelsVector(),
            Basemap.CreateLightGrayCanvasVector(),
            Basemap.CreateNavigationVector(),
            Basemap.CreateStreetsNightVector(),
            Basemap.CreateStreetsWithReliefVector(),
            Basemap.CreateDarkGrayCanvasVector()
        };

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (int index in Enum.GetValues(typeof(BasemapType)))
            {
                string basemapName = Enum.GetName(typeof(BasemapType), index);
                listbox_Basemaps.Items.Add(basemapName);
            }
            listbox_Basemaps.SelectedIndex = 0;
            AxMapView.IsAttributionTextVisible = false;
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void Btn_Ok_Click(object sender, RoutedEventArgs e)
        {
            int index = listbox_Basemaps.SelectedIndex;
            if (index != -1)
            {
                WxzUtils.AR.NewBasemap(m_pBasemaps[index]);
                this.Close(); 
            }
            else
            {
                MessageBox.Show("未选择底图");
            }
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Listbox_Basemaps_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            int index = listbox_Basemaps.SelectedIndex;
            BasemapType basemapType = (BasemapType)index;
            Map map = new Map(basemapType, 0, 0, 0);
            AxMapView.Map = map;
        }
    }
}
