using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Location;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Security;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.Tasks;
using Esri.ArcGISRuntime.UI;

namespace AddLayersToMap
{
    /// <summary>
    /// Provides map data to an application
    /// </summary>
    public class MapViewModel : INotifyPropertyChanged
    {
        public MapViewModel()
        {
            // 3. Display the new map in app
            this.CreateNewMap();
        }

        private FeatureLayer GetFeatureLayerFromUrl(string url)
        { return new FeatureLayer(new Uri(url)); }
        

        // 1. Create a new map with an imagery basemap
        private async void CreateNewMap()
        {
            Map pMap = new Map(Basemap.CreateImagery());

            // 2. Create a new map layer
                // 中国行政单元 - 面状
            FeatureLayer pFeatureLayer_CH_Boundary_poly = GetFeatureLayerFromUrl("https://services9.arcgis.com/8vu5jgpRPi7NCKmE/arcgis/rest/services/中国省级行政单元/FeatureServer/0");
                // 中国行政界线 - 线状
            FeatureLayer pFeatureLayer_CH_Boundary_arc = GetFeatureLayerFromUrl("https://services9.arcgis.com/8vu5jgpRPi7NCKmE/ArcGIS/rest/services/中国行政界线/FeatureServer/0");
                // 中国行政中心 - 点状
            FeatureLayer pFeatureLayer_CH_Admin_pt = GetFeatureLayerFromUrl("https://services9.arcgis.com/8vu5jgpRPi7NCKmE/ArcGIS/rest/services/中国省级行政中心/FeatureServer/0");

            // 异步加载图层并等待其完成
            await pFeatureLayer_CH_Boundary_poly.LoadAsync();
            await pFeatureLayer_CH_Boundary_arc.LoadAsync();
            await pFeatureLayer_CH_Admin_pt.LoadAsync();

            // 将图层添加到地图的操作图层集合中
            pMap.OperationalLayers.Add(pFeatureLayer_CH_Boundary_poly);
            pMap.OperationalLayers.Add(pFeatureLayer_CH_Boundary_arc);
            pMap.OperationalLayers.Add(pFeatureLayer_CH_Admin_pt);

            // 将地图的初始化显示区域（ViewPoint）设置为添加图层中要素的范围
            pMap.InitialViewpoint = new Viewpoint(pFeatureLayer_CH_Boundary_poly.FullExtent);

            // 更新地图
            this.Map = pMap;
        }
        
        





        // --------------------------------------------------------------

        private Map _map = new Map(Basemap.CreateStreets());

        /// <summary>
        /// Gets or sets the map
        /// </summary>
        public Map Map
        {
            get { return _map; }
            set { _map = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Raises the <see cref="MapViewModel.PropertyChanged" /> event
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var propertyChangedHandler = PropertyChanged;
            if (propertyChangedHandler != null)
                propertyChangedHandler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        

    }
}
