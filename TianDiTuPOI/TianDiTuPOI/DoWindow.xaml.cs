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

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;

namespace TianDiTuPOI
{
    /// <summary>
    /// DoWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DoWindow : Window
    {
        private IMapControl2 m_pMapC2;
        private bool _isDraw = false;
        public bool IsDraw
        { get { return this._isDraw; } }

        public DoWindow(IMapControl2 mapControl)
        {
            InitializeComponent();
            m_pMapC2 = mapControl;
        }


        #region 控件移动实现事件集
        private System.Windows.Point mousedown_location = new System.Windows.Point();
        private void Controls_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.mousedown_location = e.GetPosition(null);
            border_bg.CaptureMouse();
        }
        private void Controls_MouseMove(object sender, MouseEventArgs e)
        {
            double dx = e.GetPosition(null).X - mousedown_location.X + border_bg.Margin.Left;
            double dy = e.GetPosition(null).Y - mousedown_location.Y + border_bg.Margin.Top;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                border_bg.Margin = new Thickness(dx, dy, 0, 0);
                mousedown_location = e.GetPosition(null);
            }
        }
        private void Button_MouseUp(object sender, MouseButtonEventArgs e)
        {
            border_bg.ReleaseMouseCapture();
        }
        #endregion

        private void btn_Zoom_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if ((Label)sender == btn_ZoomIn)
            {
                m_pMapC2.MapScale *= 0.9;
                m_pMapC2.Refresh();
                return;
            }
            if ((Label)sender == btn_ZoomOut)
            {
                m_pMapC2.MapScale *= 1.1;
                m_pMapC2.Refresh();
                return;
            }

        }

        private void btn_DrawMapBound_Click(object sender, RoutedEventArgs e)
        {
            _isDraw = !_isDraw;
            if (_isDraw)
            {
                btn_DrawMapBound.Content = "关闭绘制";
            }
            else
            {
                btn_DrawMapBound.Content = "绘制范围";
            }
        }
    }
}
