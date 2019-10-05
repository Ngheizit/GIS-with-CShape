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

namespace XizheGIS.Windows
{
    /// <summary>
    /// Interaction logic for ChangeBasemapWindow.xaml
    /// </summary>
    public partial class ChangeBasemapWindow : Window
    {
        // 字典对象：底图名称 → 底图对象
        private readonly Dictionary<string, Basemap> _basemapOptions = new Dictionary<string, Basemap>()
        {
            {"Streets (Raster)", Basemap.CreateStreets()},
            {"Streets (Vector)", Basemap.CreateStreetsVector()},
            {"Streets - Night (Vector)", Basemap.CreateStreetsNightVector()},
            {"Imagery (Raster)", Basemap.CreateImagery()},
            {"Imagery with Labels (Raster)", Basemap.CreateImageryWithLabels()},
            {"Imagery with Labels (Vector)", Basemap.CreateImageryWithLabelsVector()},
            {"Dark Gray Canvas (Vector)", Basemap.CreateDarkGrayCanvasVector()},
            {"Light Gray Canvas (Raster)", Basemap.CreateLightGrayCanvas()},
            {"Light Gray Canvas (Vector)", Basemap.CreateLightGrayCanvasVector()},
            {"Navigation (Vector)", Basemap.CreateNavigationVector()},
            {"OpenStreetMap (Raster)", Basemap.CreateOpenStreetMap()}
        };

        public ChangeBasemapWindow()
        {
            InitializeComponent();
            Initialize();
            axMapView.LocationDisplay.IsEnabled = true;
        }
        private void Initialize()
        {
            // 默认加载第一份底图
            axMapView.Map = new Map(this._basemapOptions.Values.First());

            // 将底图标题设置为项目源
            BasemapChooser.ItemsSource = _basemapOptions.Keys;

            // 显示列表中的第一个底图
            BasemapChooser.SelectedIndex = 0;
        }

        private void OnBasemapChooserSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 获取所选底图的标题
            string selectedBasemapTitle = e.AddedItems[0].ToString();

            // 从字典中检索底图
            axMapView.Map.Basemap = _basemapOptions[selectedBasemapTitle];

            // Basemap对象测试
            print(axMapView.Map.Basemap.Name);
            print(axMapView.Map.Basemap.LoadStatus.ToString());
        }
        private void print(string str)
        { tbx_info.Text += "$ " + str + "\n"; }

     
    }
}
