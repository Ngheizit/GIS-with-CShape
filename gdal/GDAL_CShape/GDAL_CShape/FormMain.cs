using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;


using OSGeo.OGR;

namespace GDAL_CShape
{
    

    public partial class FormMain : Form
    {

        private double m_pMinX, m_pMaxX, m_pMinY, m_pMaxY;
        private string m_path;


        public FormMain()
        {
            InitializeComponent();
            #region 驱动GDAL库
            GdalConfiguration.ConfigureGdal();
            GdalConfiguration.ConfigureOgr();
            OSGeo.GDAL.Gdal.AllRegister(); 
            #endregion
        }

        #region GDAL函数
        private static string GetVector_SpactialRef(string filepath)
        {
            string info = "";
            DataSource ds = Ogr.Open(filepath, 0);
            if (ds == null)
                return info = "Can not open " + filepath;
            Driver drv = ds.GetDriver();
            if (drv == null)
                return info = "Can not get driver";
            string srs_wkt = "";
            for (int iLayer = 0; iLayer < ds.GetLayerCount(); iLayer++)
            {
                Layer layer = ds.GetLayerByIndex(iLayer);
                if (layer == null)
                    return info = "FAILURE: Couldn't fetch advertised layer" + iLayer;
                OSGeo.OSR.SpatialReference sr = layer.GetSpatialRef();
                if (sr != null)
                    sr.ExportToPrettyWkt(out srs_wkt, 1);
                else
                    srs_wkt = "unKononw";
            }
            return "空间参考：\n" + srs_wkt;
        }
        private static string GetVector_GeomeInfo(string filepath)
        {
            string info = "";
            DataSource ds = Ogr.Open(filepath, 0);
            if (ds == null)
                return info = "Can not open " + filepath;
            Driver drv = ds.GetDriver();
            if (drv == null)
                return info = "Can not get driver";
            for (int iLayer = 0; iLayer < ds.GetLayerCount(); iLayer++)
            {
                Layer layer = ds.GetLayerByIndex(iLayer);
                if (layer == null)
                {
                    return info = "FAILURE: Couldn't fetch advertised layer" + iLayer;
                }
                Feature feat;
                while ((feat = layer.GetNextFeature()) != null)
                {
                    Geometry geom = feat.GetGeometryRef();
                    if (geom != null)
                    {
                        string geom_wkt;
                        geom.ExportToWkt(out geom_wkt);
                        info += geom_wkt + "\n";
                    }
                    feat.Dispose();
                }
            }
            return info;

        }
        private static double[] GetVector_Extent(string filepath)
        {
            DataSource ds = Ogr.Open(filepath, 0);
            Driver drv = ds.GetDriver();
            double[] extent = new double[4];
            for (int iLayer = 0; iLayer < ds.GetLayerCount(); iLayer++)
            {
                Layer layer = ds.GetLayerByIndex(iLayer);
                Envelope ext = new Envelope();
                layer.GetExtent(ext, 1);
                extent[0] = ext.MinX;
                extent[1] = ext.MaxX;
                extent[2] = ext.MinY;
                extent[3] = ext.MaxY;
            }
            return extent;
        }
        #endregion

        private void Form_Load(object sender, EventArgs e)
        {
            #region 目录空间设置
            foreach (string driver in Environment.GetLogicalDrives())
            {
                var dir = new DriveInfo(driver);
                switch (dir.DriveType)
                {
                    case DriveType.Fixed:
                        TreeNode tNode = new TreeNode(dir.Name.Split(':')[0]);
                        tNode.Name = dir.Name;
                        tNode.Tag = tNode.Name;
                        this.treeView_Dir.Nodes.Add(tNode);
                        tNode.Nodes.Add("");
                        tNode.Expand();
                        break;
                }
            } 
            #endregion
        }



        #region 目录空间设置事件
        private void TreeView_Dir_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.m_path = e.Node.Name;
            tbx_showPath.Text = m_path;
            if (m_path.Split('.')[m_path.Split('.').Length - 1] == "shp")
            {
                string geomeInfo = GetVector_GeomeInfo(m_path);
                double[] extent = GetVector_Extent(m_path);
                rtbx_spactialRef.Text = String.Format("MinX: {0}; \nMaxX: {1}; \nMinY: {2}; \nMaxY: {3}; \n", extent[0], extent[1], extent[2], extent[3]);
                //rtbx_spactialRef.Text = geomeInfo;
                this.m_pMinX = extent[0];
                this.m_pMaxX = extent[1];
                this.m_pMinY = extent[2];
                this.m_pMaxY = extent[3];
                string geomeType = geomeInfo.Split(' ')[0];
                rtbx_test.Text = geomeType;

                string str = "";
                Graphics g = pictureBox_shp.CreateGraphics();
                g.Clear(Color.White);
                foreach (string sLocInfo in geomeInfo.Split(geomeType.ToCharArray()))
                {
                    if (sLocInfo != string.Empty)
                    {
                        str += sLocInfo;
                        if (geomeType == "POINT")
                        {
                            string str_point = sLocInfo.Substring(2, sLocInfo.IndexOf(')') - 2);
                            double x = Convert.ToDouble(str_point.Split(' ')[0]);
                            double y = Convert.ToDouble(str_point.Split(' ')[1]);
                            m2e(ref x, ref y);
                            //MessageBox.Show(x.ToString() + ", " + y.ToString());
                            Point pt = new Point((int)x, (int)y);
                            //g.DrawLine(new Pen(Color.Black, 4), pt, new Point(pt.X + 4, pt.Y + 4));
                            g.DrawEllipse(new Pen(Color.Black), pt.X, pt.Y, 4, 4);
                            continue;
                        }
                        if(geomeType == "LINESTRING")
                        {
                            string str_points = sLocInfo.Substring(2, sLocInfo.IndexOf(')') - 2);
                            int i = 0;
                            Point fPt = new Point();
                            foreach (string sLinePts in str_points.Split(','))
                            {
                                double x = Convert.ToDouble(sLinePts.Split(' ')[0]);
                                double y = Convert.ToDouble(sLinePts.Split(' ')[1]);
                                m2e(ref x, ref y);
                                Point tPt = new Point((int)x, (int)y);
                                if(i != 0)
                                {
                                    g.DrawLine(new Pen(Color.Black, 1), fPt, tPt);
                                }
                                fPt = tPt;
                                i++;
                            }
                            continue;
                        }
                        if(geomeType == "POLYGON")
                        {
                            string str_points = "";
                            try
                            {
                                str_points = sLocInfo.Substring(2, sLocInfo.LastIndexOf(')') - 2);
                            }
                            catch
                            {
                                continue;
                            }
                            List<Point> points = new List<Point>();
                            int i = 0;
                            foreach (string s in str_points.Split("),(".ToCharArray()))
                            {
                                if (s != string.Empty)
                                {
                                    double x = Convert.ToDouble(s.Split(' ')[0]);
                                    double y = Convert.ToDouble(s.Split(' ')[1]);
                                    m2e(ref x, ref y);
                                    Point Pt = new Point((int)x, (int)y);
                                    points.Add(Pt);
                                    //if (i == 0)
                                    //    startPoint = Pt;
                                    //else
                                    //{
                                    //    if (startPoint.X == Pt.X && startPoint.Y == Pt.Y)
                                    //        break;
                                    //}
                                }
                                i++;
                            }
                            g.FillPolygon(Brushes.Red, points.ToArray(), System.Drawing.Drawing2D.FillMode.Winding);
                            g.DrawLines(new Pen(Brushes.White, 1), points.ToArray());
                        }
                    }
                }
                rtbx_loca.Text = str;


            }

        }

        private void TreeView_Dir_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.Expand();
        }

        private void TreeView_Dir_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeViewItems.Add(e.Node);
        }

        #region TreeViewItems类
        public static class TreeViewItems
        {
            public static void Add(TreeNode e)
            {
                try
                {
                    if (e.Tag.ToString() != "This PC")
                    {
                        e.Nodes.Clear();
                        TreeNode tNode = e;
                        string path = tNode.Name;
                        string[] dics = Directory.GetDirectories(path);
                        foreach (string dic in dics)
                        {
                            TreeNode subNode = new TreeNode(new DirectoryInfo(dic).Name);
                            subNode.Name = new DirectoryInfo(dic).FullName;
                            subNode.Tag = subNode.Name;
                            tNode.Nodes.Add(subNode);
                            subNode.Nodes.Add("");
                        }
                        string[] strFiles = Directory.GetFiles(path);
                        foreach (string str in strFiles)
                        {
                            if (str.Split('.')[str.Split('.').Length - 1] == "shp")
                            {
                                TreeNode subNode = new TreeNode(Path.GetFileName(str));
                                subNode.Name = Path.GetDirectoryName(str) + "\\" + Path.GetFileName(str);
                                subNode.Tag = subNode.Name;
                                tNode.Nodes.Add(subNode);
                            }
                        }
                    }
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.Message);
                }
            }
        }
        #endregion

        #endregion


        #region 在任务管理器中打开当前目录
        private void Btn_openiInWindow_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            if (m_path.Split('.')[m_path.Split('.').Length - 1] == "shp")
                System.Diagnostics.Process.Start("Explorer.exe", System.IO.Path.GetDirectoryName(this.m_path));
            else
                System.Diagnostics.Process.Start("Explorer.exe", this.m_path);
        }
        #endregion

        #region 将Shapefile文件集压缩为Zip压缩包
        private void Btn_shp2zip_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfg = new SaveFileDialog();
            sfg.Title = "Save as";
            sfg.Filter = "zip files (*.zip)|*.zip";
            if (sfg.ShowDialog() == DialogResult.OK)
            {

            }
        } 
        #endregion

        #region 绘制矢量数据
        private void e2m(ref double x, ref double y)
        {

            double height = pictureBox_shp.Height;
            double width = pictureBox_shp.Width;

            double y_distance = this.m_pMaxY - this.m_pMinY;
            double x_distance = this.m_pMaxX - this.m_pMinX;
            if (x_distance > y_distance)
                y_distance += (x_distance - y_distance);
            else if (x_distance < y_distance)
                x_distance += (y_distance - x_distance);

            double x_persent = x / width;
            double y_persent = y / height;

            x = this.m_pMinX + (x_persent * x_distance);
            y = this.m_pMinY + (y_persent * y_distance);

            y = y_distance - y;
        }
        private void m2e(ref double x, ref double y)
        {
            double height = pictureBox_shp.Height;
            double width = pictureBox_shp.Width;

            double y_distance = this.m_pMaxY - this.m_pMinY;
            double x_distance = this.m_pMaxX - this.m_pMinX;
            if (x_distance > y_distance)
                y_distance += (x_distance - y_distance);
            else if (x_distance < y_distance)
                x_distance += (y_distance - x_distance);

            double x_persent = (x - this.m_pMinX) / x_distance;
            double y_persent = (y - this.m_pMinY) / y_distance;

            x = x_persent * width;
            y = y_persent * height;

            y = height - y;
        }
        private void PictureBox_shp_MouseMove(object sender, MouseEventArgs e)
        {
            double x = e.X;
            double y = e.Y;
            e2m(ref x, ref y);

            string xys = "x = " + x + ", " + y;
            footlabel_xy.Text = xys;
        } 
        #endregion
    }
}
