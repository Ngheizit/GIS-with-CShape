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
using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;

namespace XizheGIS.Windows
{
    /// <summary>
    /// Interaction logic for AddFeaturesWindow.xaml
    /// </summary>
    public partial class AddFeaturesWindow : Window
    {
        public AddFeaturesWindow()
        {
            InitializeComponent();
            this.Initialize();
        }

        // 要素服务路径
        private const string FeatureServiceUrl = "https://sampleserver6.arcgisonline.com/arcgis/rest/services/DamageAssessment/FeatureServer/0";

        // 要素属性表引用
        private ServiceFeatureTable _featureTable;

        private void Initialize()
        {
            // 创建底图
            axMapView.Map = new Map(Basemap.CreateStreets());

            // 创建要素属性表
            this._featureTable = new ServiceFeatureTable(new Uri(FeatureServiceUrl));

            // 创建要素图层以可视化要素属性表
            FeatureLayer featureLayer = new FeatureLayer(this._featureTable);

            // 添加要素图层
            axMapView.Map.OperationalLayers.Add(featureLayer);

            // 添加MapView空间的点击监听事件
            axMapView.GeoViewTapped += MapView_Tapped;

            axMapView.SetViewpointCenterAsync(new MapPoint(-10800000, 4500000, SpatialReferences.WebMercator), 3e7);

        }

        private async void MapView_Tapped(object sender, Esri.ArcGISRuntime.UI.Controls.GeoViewInputEventArgs e)
        {
            try
            {
                // 创建要素
                ArcGISFeature feature = this._featureTable.CreateFeature() as ArcGISFeature;

                // 获取点击位置并转换为地理坐标
                MapPoint tappedPoint = (MapPoint)GeometryEngine.NormalizeCentralMeridian(e.Location);

                // 设置要素属性 (字段, 属性)
                feature.SetAttributeValue("typdamage", "Minor");
                feature.SetAttributeValue("primcause", "Earthquake");

                // 添加要素至属性表
                await this._featureTable.AddFeatureAsync(feature);

                // 运行服务编辑
                await this._featureTable.ApplyEditsAsync();

                // 更新服务
                feature.Refresh();

                MessageBox.Show("Created feature " + feature.Attributes["objectid"], "Success!");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString(), "Error adding feature");
            }
        }
    }
}
