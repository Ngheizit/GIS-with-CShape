using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using ESRI.ArcGIS.esriSystem;

namespace TianDiTuPOI
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeEngineLicense();
        }

        private void InitializeEngineLicense()
        {
            AoInitialize aoi = new AoInitializeClass();

            //more license choices could be included here

            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.Desktop);

            //esriLicenseProductCode productCode = esriLicenseProductCode.esriLicenseProductCodeEngine;
            //if (aoi.IsProductCodeAvailable(productCode) == esriLicenseStatus.esriLicenseAvailable)
            //{
            //    aoi.Initialize(productCode);
            //}
        }
    }
}
