using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDAL_Console
{
    class GdalUtils
    {
        /// <summary>
        /// 激活GDAL
        /// </summary>
        public static void ActiveGDAL()
        {
            GdalConfiguration.ConfigureGdal();
            GdalConfiguration.ConfigureOgr();
            OSGeo.GDAL.Gdal.AllRegister();
        }
        
    }
}
