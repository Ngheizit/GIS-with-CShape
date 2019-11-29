using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.UI.Controls;

namespace WuxizheGIS.WxzUtils
{
    class AR
    {
        public static void SetLicense()
        {
            string liscenseKey = "runtimelite,1000,rud2630151591,none,PM0RJAY3FP20463EM070";
            Esri.ArcGISRuntime.ArcGISRuntimeEnvironment.SetLicense(liscenseKey);
        }
        private static MapView m_axMapView;
        public static void SetMapView(MapView mapView)
        {
            m_axMapView = mapView;
            m_axMapView.IsAttributionTextVisible = false; // 去除底部引用内容
        }

        public static void LoadDefaultMap()
        {
            Map pMap = new Map(BasemapType.Imagery, 0, 114, 0);
            m_axMapView.Map = pMap;
        }
        public static void NewBasemap(Basemap basemap)
        {
            m_axMapView.Map.Basemap = basemap;
        }

    }
}
