using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Esri.ArcGISRuntime.Mapping;

namespace NgheizitRuntime
{
    class NgheizitTools
    {
        /// <summary>
        /// 通过URL值加载ArcGIS Online矢量图层
        /// </summary>
        /// <param name="map">所需加载图层的地图</param>
        /// <param name="urls">URL值</param>
        public static async void AddFeatureLayersFromUrls(Map map, params string[] urls)
        {
            foreach(string url in urls)
            {
                FeatureLayer pFeatureLayer = new FeatureLayer(new Uri(url));
                // 异步加载图层并等待完成
                await pFeatureLayer.LoadAsync();
                // 将图层添加到地图的操作图层集合中
                map.OperationalLayers.Add(pFeatureLayer);
                // 将地图的初始化显示区域（ViewPoint）设置为添加地图中要素的范围
                map.InitialViewpoint = new Viewpoint(pFeatureLayer.FullExtent);
            }
        }
    }
}
