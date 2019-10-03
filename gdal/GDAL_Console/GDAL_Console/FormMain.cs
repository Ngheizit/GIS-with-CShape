using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OSGeo.OGR;

namespace GDAL_Console
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        private void print(object str)
        {
            rtbx_console.Text += "& " + str.ToString() + "\n";
        }
        private void print(object str, params object[] obj)
        {
            rtbx_console.Text += "& " + String.Format(str.ToString(), obj) + "\n";
        }
        private void print(int n, object str)
        {
            string space = "";
            for(int i = 0; i < n * 4; i++)
            { space += " "; }
            rtbx_console.Text += "& " + space + str.ToString() + "\n";
        }
        private void print(int n, object str, params object[] obj)
        {
            string space = "";
            for (int i = 0; i < n * 4; i++)
            { space += " "; }
            rtbx_console.Text += "& " + space + String.Format(str.ToString(), obj) + "\n";
        }

        private void Console(object sender, EventArgs e)
        {
            GdalUtils.ActiveGDAL();

            //this.ReadShapefile();
            //this.WriteShapefile();



        }

        /// <summary>
        /// 读取矢量要素
        /// </summary>
        private void ReadShapefile()
        {
            // 加载数据驱动和数据源
            string filename = @"D:\gitproj\gis2python\gdal\china\Cities.shp";
            Driver driver = Ogr.GetDriverByName("ESRI Shapefile");
            DataSource dataSource = driver.Open(filename, 0);
            if (dataSource == null)
            {
                print("could not open " + filename);
                return;
            }
            print("要素类{0}加载成功", filename);

            // 读取数据层
            Layer layer = dataSource.GetLayerByIndex(0);
            long count = layer.GetFeatureCount(0);
            print("该要素类拥有{0}个要素", count);

            //// 读取要素类的范围
            //Envelope envelope = new Envelope();
            //int extent = layer.GetExtent(envelope, 0);
            //print(extent);

            // 遍历要素类的要素
            Feature feat = layer.GetNextFeature();
            print("数据几何信息：");
            while (feat != null)
            {
                Geometry geom = feat.GetGeometryRef();
                print(1, "({0}, {1})", geom.GetX(0), geom.GetY(0));
                feat = layer.GetNextFeature();
            }

            dataSource.Dispose();
        }

        /// <summary>
        /// 写入矢量要素
        /// </summary>
        private void WriteShapefile()
        {
            // 删除矢量数据
            Driver driver = Ogr.GetDriverByName("ESRI Shapefile");
            string filename = @"D:\gitproj\gis2python\gdal\temp\create.shp";
            driver.DeleteDataSource(filename);
            print("数据{0}已被删除", filename);

            // 创建矢量数据
            DataSource dataSource = driver.CreateDataSource(filename, null);
            Layer layer = dataSource.CreateLayer("create", null, wkbGeometryType.wkbPoint, null);
            print("数据{0}已创建", filename);

            // 新建字段
            FieldDefn fieldDefn = new FieldDefn("id", FieldType.OFTString);
            fieldDefn.SetWidth(4);
            layer.CreateField(fieldDefn, 0);
            print("字段 id 已创建");

            // 创建要素
            FeatureDefn featureDefn = layer.GetLayerDefn();
            Feature feat = new Feature(featureDefn);
            string point = "POINT(2.0 3.2)";
            Geometry geom = Ogr.CreateGeometryFromWkt(ref point, null);
            feat.SetGeometry(geom);
            feat.SetField("id", 3);
            layer.CreateFeature(feat);
            print("要素{0}已创建", feat);

            dataSource.Dispose();
        }

    }
}
