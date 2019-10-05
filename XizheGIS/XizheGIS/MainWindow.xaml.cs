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
using System.Windows.Threading;

namespace XizheGIS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;

        private void ShowTimer(object sender, EventArgs e)
        {
            this.tbk_time.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        public MainWindow()
        {
            InitializeComponent();
            #region 启动Timer
            this.timer = new DispatcherTimer();
            this.timer.Tick += new EventHandler(ShowTimer);
            this.timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            this.timer.Start();
            #endregion
        }

        ContextMenu contextMenu = new ContextMenu();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            border_menu.ContextMenu = contextMenu;
            AddMenuItem("test", "Hello");
            AddMenuItem("test2", "Hello");
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            switch((sender as MenuItem).Name)
            {
                case "test":
                    MessageBox.Show("");
                    break;
            }
        }
        private void AddMenuItem(string id, string name)
        {
            MenuItem item = new MenuItem();
            item.Name = id;
            item.Header = name;
            item.Click += MenuItem_Click;
            contextMenu.Items.Add(item);
        }





        #region 控件移动实现事件集
        private Point mousedown_location = new Point();
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


    }
}
