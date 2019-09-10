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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.Geometry;

namespace NgheizitRuntime
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        private Map pMap;

        public MainWindow()
        {
            InitializeComponent();

            #region 设置许可应用
            string licenseKsy = "runtimelite,1000,rud2630151591,none,PM0RJAY3FP20463EM070";
            Esri.ArcGISRuntime.ArcGISRuntimeEnvironment.SetLicense(licenseKsy);
            #endregion

            #region 初始化底图
            pMap = new Map(Basemap.CreateStreets()); 
            axMapView.Map = this.pMap; // 将pMap变量的地址传给axMapView.Map，即axMapView.Map随pMap的变化而变化
            #endregion

            #region 初始图层加载
            NgheizitTools.AddFeatureLayersFromUrls(pMap,
                    "https://services9.arcgis.com/8vu5jgpRPi7NCKmE/arcgis/rest/services/中国省级行政单元/FeatureServer/0", // Polygon
                    "https://services9.arcgis.com/8vu5jgpRPi7NCKmE/ArcGIS/rest/services/中国行政界线/FeatureServer/0", // Polyline
                    "https://services9.arcgis.com/8vu5jgpRPi7NCKmE/ArcGIS/rest/services/中国省级行政中心/FeatureServer/0" // Point
                );
            #endregion

            #region 初始状态隐藏功能区
            gpbx_symbolic_simple.Visibility = Visibility.Hidden;  // FeatureLayer 符号化功能区
            #endregion
        }


        #region -----------------单一符号化-----------------
        #region 按钮点击事件
        private void Buttons_Cilck(object sender, RoutedEventArgs e)
        {
            #region 单一符号化符号化按钮集
            #region 1. 单一符号化功能区开启按钮
            if ((Button)sender == btn_symbolic)
            {
                gpbx_symbolic_simple.Visibility = Visibility.Visible; // 显示单一符号化功能区
                int len = axMapView.Map.OperationalLayers.Count; // 获得当前底图图层数量
                #region 清理并将图层名称和符号样式载入各自的Combobox空间内
                cbb_symbol_simple_SelectLayer.Items.Clear();
                for (int i = 0; i < len; i++)
                {
                    cbb_symbol_simple_SelectLayer.Items.Add(axMapView.Map.OperationalLayers[i].Name);
                }
                #endregion
                return;

            }
            #endregion
            #region 2. 单一符号化功能执行按钮
            if ((Button)sender == btn_symbol_simple_OK)
            {
                int index = cbb_symbol_simple_SelectLayer.SelectedIndex; // 需要执行符号化的图层索引
                FeatureLayer pFeatureLayer = axMapView.Map.OperationalLayers[index] as FeatureLayer;
                #region 设置颜色及尺寸
                byte r = (byte)slider_symbol_simple_red.Value;
                byte g = (byte)slider_symbol_simple_green.Value;
                byte b = (byte)slider_symbol_simple_blue.Value;
                System.Drawing.Color color = System.Drawing.Color.FromArgb(r, g, b);
                double size = slider_symbol_simple_size.Value;
                #endregion
                GeometryType pGeometryType = pFeatureLayer.FeatureTable.GeometryType;
                if (pGeometryType == GeometryType.Point) // 点状要素
                {
                    SimpleMarkerSymbolStyle pSimpleMarkerSymbolStyle = (SimpleMarkerSymbolStyle)cbb_symbol_simple_SelectStyle.SelectedIndex;
                    SimpleMarkerSymbol pSimpleMarkerSymbol = new SimpleMarkerSymbol(
                        pSimpleMarkerSymbolStyle, color, size
                    );
                    SimpleRenderer pSimpleRenderer = new SimpleRenderer(pSimpleMarkerSymbol);
                    pFeatureLayer.Renderer = pSimpleRenderer;
                }
                else if (pGeometryType == GeometryType.Polyline)
                {
                    SimpleLineSymbolStyle pSimpleLineSymbolStyle = (SimpleLineSymbolStyle)cbb_symbol_simple_SelectStyle.SelectedIndex;
                    SimpleLineSymbol pSimpleLineSymbol = new SimpleLineSymbol(
                       pSimpleLineSymbolStyle, color, size
                    );
                    SimpleRenderer pSimpleRenderer = new SimpleRenderer(pSimpleLineSymbol);
                    pFeatureLayer.Renderer = pSimpleRenderer;
                }
                else if (pGeometryType == GeometryType.Polygon)
                {
                    SimpleFillSymbolStyle pSimpleFillSymbolStyle = (SimpleFillSymbolStyle)cbb_symbol_simple_SelectStyle.SelectedIndex;
                    byte r_outline = (byte)slider_symbol_simple_red2.Value;
                    byte g_outline = (byte)slider_symbol_simple_green2.Value;
                    byte b_outline = (byte)slider_symbol_simple_blue2.Value;
                    System.Drawing.Color color_outline = System.Drawing.Color.FromArgb(r_outline, g_outline, b_outline);
                    SimpleLineSymbolStyle pSimpleLineSymbolStyle = (SimpleLineSymbolStyle)cbb_symbol_simple_SelectStyle_outline.SelectedIndex;
                    SimpleLineSymbol pSimpleLineSymbol_outline = new SimpleLineSymbol(
                        pSimpleLineSymbolStyle, color_outline, size
                    );
                    SimpleFillSymbol pSimpleFillSymbol = new SimpleFillSymbol(
                        pSimpleFillSymbolStyle, color, pSimpleLineSymbol_outline
                    );
                    SimpleRenderer pSimpleRenderer = new SimpleRenderer(pSimpleFillSymbol);
                    pFeatureLayer.Renderer = pSimpleRenderer;
                }
                axMapView.Map.OperationalLayers[index] = pFeatureLayer; // 更新符号化图层
                return;
            }
            #endregion
            #region 3. 单一符号化功能关闭按钮
            if ((Button)sender == btn_symbol_simple_Close)
            {
                gpbx_symbolic_simple.Visibility = Visibility.Hidden; // 隐藏符号化功能区
                return;
            }
            #endregion
            #endregion
        }
        #endregion

        #region 滑动条滑动事件
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            #region 单一符号化滑动条集
            #region 1. 单一符号化符号尺寸设置滑动条
            if ((Slider)sender == slider_symbol_simple_size)
            {
                label_symbol_simple_size.Content = "调整符号大小：" + slider_symbol_simple_size.Value.ToString(".#");
                return;
            }
            #endregion
            #region 2. 单一符号化符号颜色设置滑动条（3个）
            if ((Slider)sender == slider_symbol_simple_red ||
                    (Slider)sender == slider_symbol_simple_green ||
                    (Slider)sender == slider_symbol_simple_blue)
            {
                byte r = (byte)slider_symbol_simple_red.Value;
                byte g = (byte)slider_symbol_simple_green.Value;
                byte b = (byte)slider_symbol_simple_blue.Value;
                label2_symbol_simple_color.Foreground = new SolidColorBrush(Color.FromRgb(r, g, b));
            }
            #endregion
            #endregion
        }
        #endregion

        #region Combobox选择项变化时间
        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((ComboBox)sender == cbb_symbol_simple_SelectLayer)
            {
                int index = cbb_symbol_simple_SelectLayer.SelectedIndex;
                FeatureLayer pFeatureLayer = this.pMap.OperationalLayers[index] as FeatureLayer;
                GeometryType pGeometryType = pFeatureLayer.FeatureTable.GeometryType;
                double width;
                switch (pGeometryType)
                {
                    case GeometryType.Point:
                        cbb_symbol_simple_SelectStyle.Items.Clear();
                        cbb_symbol_simple_SelectStyle.Items.Add(SimpleMarkerSymbolStyle.Circle);
                        cbb_symbol_simple_SelectStyle.Items.Add(SimpleMarkerSymbolStyle.Cross);
                        cbb_symbol_simple_SelectStyle.Items.Add(SimpleMarkerSymbolStyle.Diamond);
                        cbb_symbol_simple_SelectStyle.Items.Add(SimpleMarkerSymbolStyle.Square);
                        cbb_symbol_simple_SelectStyle.Items.Add(SimpleMarkerSymbolStyle.Triangle);
                        cbb_symbol_simple_SelectStyle.Items.Add(SimpleMarkerSymbolStyle.X);
                        width = StackPanel_symbol_simole_setColor.Width;
                        slider_symbol_simple_red.Width = width;
                        slider_symbol_simple_green.Width = width;
                        slider_symbol_simple_blue.Width = width;
                        slider_symbol_simple_red2.Width = 0;
                        slider_symbol_simple_green2.Width = 0;
                        slider_symbol_simple_blue2.Width = 0;
                        label2_symbol_simple_color_oulline.Visibility = Visibility.Hidden;
                        label_symbol_simple_selectionstyle_outline.Visibility = Visibility.Hidden;
                        cbb_symbol_simple_SelectStyle_outline.Visibility = Visibility.Hidden;
                        break;
                    case GeometryType.Polyline:
                        cbb_symbol_simple_SelectStyle.Items.Clear();
                        cbb_symbol_simple_SelectStyle.Items.Add(SimpleLineSymbolStyle.Dash);
                        cbb_symbol_simple_SelectStyle.Items.Add(SimpleLineSymbolStyle.DashDot);
                        cbb_symbol_simple_SelectStyle.Items.Add(SimpleLineSymbolStyle.DashDotDot);
                        cbb_symbol_simple_SelectStyle.Items.Add(SimpleLineSymbolStyle.Dot);
                        cbb_symbol_simple_SelectStyle.Items.Add(SimpleLineSymbolStyle.Null);
                        cbb_symbol_simple_SelectStyle.Items.Add(SimpleLineSymbolStyle.Solid);
                        width = StackPanel_symbol_simole_setColor.Width;
                        slider_symbol_simple_red.Width = width;
                        slider_symbol_simple_green.Width = width;
                        slider_symbol_simple_blue.Width = width;
                        slider_symbol_simple_red2.Width = 0;
                        slider_symbol_simple_green2.Width = 0;
                        slider_symbol_simple_blue2.Width = 0;
                        label2_symbol_simple_color_oulline.Visibility = Visibility.Hidden;
                        label_symbol_simple_selectionstyle_outline.Visibility = Visibility.Hidden;
                        cbb_symbol_simple_SelectStyle_outline.Visibility = Visibility.Hidden;
                        break;
                    case GeometryType.Polygon:
                        cbb_symbol_simple_SelectStyle.Items.Clear();
                        cbb_symbol_simple_SelectStyle.Items.Add(SimpleFillSymbolStyle.BackwardDiagonal);
                        cbb_symbol_simple_SelectStyle.Items.Add(SimpleFillSymbolStyle.Cross);
                        cbb_symbol_simple_SelectStyle.Items.Add(SimpleFillSymbolStyle.DiagonalCross);
                        cbb_symbol_simple_SelectStyle.Items.Add(SimpleFillSymbolStyle.ForwardDiagonal);
                        cbb_symbol_simple_SelectStyle.Items.Add(SimpleFillSymbolStyle.Horizontal);
                        cbb_symbol_simple_SelectStyle.Items.Add(SimpleFillSymbolStyle.Null);
                        cbb_symbol_simple_SelectStyle.Items.Add(SimpleFillSymbolStyle.Solid);
                        cbb_symbol_simple_SelectStyle.Items.Add(SimpleFillSymbolStyle.Vertical);
                        width = StackPanel_symbol_simole_setColor.Width;
                        slider_symbol_simple_red.Width = width / 2;
                        slider_symbol_simple_green.Width = width / 2;
                        slider_symbol_simple_blue.Width = width / 2;
                        slider_symbol_simple_red2.Width = width / 2;
                        slider_symbol_simple_green2.Width = width / 2;
                        slider_symbol_simple_blue2.Width = width / 2;
                        label2_symbol_simple_color_oulline.Visibility = Visibility.Visible;
                        label_symbol_simple_selectionstyle_outline.Visibility = Visibility.Visible;
                        cbb_symbol_simple_SelectStyle_outline.Visibility = Visibility.Visible;
                        cbb_symbol_simple_SelectStyle_outline.Items.Clear();
                        cbb_symbol_simple_SelectStyle_outline.Items.Add(SimpleLineSymbolStyle.Dash);
                        cbb_symbol_simple_SelectStyle_outline.Items.Add(SimpleLineSymbolStyle.DashDot);
                        cbb_symbol_simple_SelectStyle_outline.Items.Add(SimpleLineSymbolStyle.DashDotDot);
                        cbb_symbol_simple_SelectStyle_outline.Items.Add(SimpleLineSymbolStyle.Dot);
                        cbb_symbol_simple_SelectStyle_outline.Items.Add(SimpleLineSymbolStyle.Null);
                        cbb_symbol_simple_SelectStyle_outline.Items.Add(SimpleLineSymbolStyle.Solid);
                        break;
                }
            }
        }  
        #endregion
        #endregion

    }
}
