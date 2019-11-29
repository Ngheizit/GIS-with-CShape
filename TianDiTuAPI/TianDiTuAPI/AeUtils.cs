using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;

namespace TianDiTuAPI
{
    class AeUtils
    {
        private static IMapControl2 m_pMapC2;
        public static void SetMapControl(IMapControl2 mapControl)
        {
            m_pMapC2 = mapControl;
        }
        private static IMapDocument m_pMapDoc;
        public static void SetMapDocment(IMapDocument mapDocument)
        {
            m_pMapDoc = mapDocument;
        }
        private static IEnvelope pHomeEnv;

        public static void LoadMxd(string mxdPath)
        {
            if (m_pMapC2.CheckMxFile(mxdPath))
            {
                m_pMapDoc.Open(mxdPath);
                m_pMapC2.Map = m_pMapDoc.Map[0];

                pHomeEnv = m_pMapC2.Extent;
            }
            else
            {
                MessageBox.Show(String.Format("无法打开【{0}】地图文档", mxdPath));
            }
        }

        public static void ZoomIn()
        { 
            m_pMapC2.MapScale *= 0.8;
            m_pMapC2.Refresh();
        }
        public static void ZoomOut()
        {
            m_pMapC2.MapScale *= 1.2;
            m_pMapC2.Refresh();
        }

        public static void Pan()
        {
            m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerPanning;
            m_pMapC2.Pan();
            m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;
        }
        public static IEnvelope TrackRectangle()
        {
            m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
            IEnvelope pEnv = m_pMapC2.TrackRectangle();
            m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;
            return pEnv;
        }

        public static void ZoomToEnvlope(IEnvelope envelope)
        {
            m_pMapC2.Extent = envelope;
            m_pMapC2.Refresh();
        }
        public static void ZoomToHome()
        {
            m_pMapC2.Extent = pHomeEnv;
            m_pMapC2.Refresh();
        }
        public static void UpdateHome()
        {
            m_pMapDoc.Save();
            pHomeEnv = m_pMapC2.Extent;
            MessageBox.Show("主页范围已更新");
        }

        public static IRgbColor CreateRgbColor(byte r, byte g, byte b, byte a = 255)
        {
            return new RgbColorClass() { 
                Red = r, Green = g, Blue = b, Transparency = a,
                UseWindowsDithering = true
            };
        }
        public static IRgbColor CreateRgbColor(byte a)
        {
            return new RgbColorClass() { 
                Transparency = a
            };
        }

        public static ISimpleFillSymbol CreateSimpleFillSymbol(IRgbColor fillColor, IRgbColor borderColor, int borderWidth)
        {
            return new SimpleFillSymbolClass() { 
                Color = fillColor,
                Outline = new SimpleLineSymbolClass(){
                    Color = borderColor,
                    Width = borderWidth
                }
            };
        }

        public static void DrawExtent(IEnvelope envelope, ISimpleFillSymbol fillSymbol)
        {
            IGraphicsContainer pGC = m_pMapC2.Map as IGraphicsContainer;
            pGC.DeleteAllElements();
            IElement pElement = new RectangleElementClass() { 
                Geometry = envelope,
                Symbol = fillSymbol
            };
            pGC.AddElement(pElement, 0);
            m_pMapC2.Refresh(esriViewDrawPhase.esriViewGraphics);
        }


        private struct CPoint
        {
            public string hotPointID;
            public double lon;
            public double lat;
            public string name;
            public string ename;
            public string address;
            public string phone;
            public string eaddress;
        }
        private static List<string> pColumns;
        private static List<CPoint> GetPoints(string csvPath)
        {
            List<CPoint> pList = new List<CPoint>();
            pColumns = new List<string>();
            char[] charArray = new char[] { ',' };
            System.IO.FileStream fs = new System.IO.FileStream(csvPath, System.IO.FileMode.Open);
            System.IO.StreamReader sr = new System.IO.StreamReader(fs, Encoding.UTF8);
            string strLine = sr.ReadLine();
            if (strLine != null)
            {
                string[] strArr = strLine.Split(charArray);
                if (strArr.Length > 0)
                {
                    for (int i = 0; i < strArr.Length; i++)
                        pColumns.Add(strArr[i]);
                }
                FormRuntime rtime = new FormRuntime(1000);
                rtime.Show();
                while ((strLine = sr.ReadLine()) != null)
                {
                    rtime.Go();
                    strArr = strLine.Split(charArray);
                    CPoint pCPoint = new CPoint();
                    pCPoint.hotPointID = strArr[0];
                    pCPoint.lon = Convert.ToDouble(strArr[1]);
                    pCPoint.lat = Convert.ToDouble(strArr[2]);
                    pCPoint.name = strArr[3];
                    pCPoint.ename = strArr[4];
                    pCPoint.address = strArr[5];
                    pCPoint.phone = strArr[6];
                    pCPoint.eaddress = strArr[7];
                    pList.Add(pCPoint);
                }
                rtime.Ok();
            }
            else
                return null;
            sr.Close();
            return pList;
        }
        private static IFeatureLayer CreateShpFromPoints(List<CPoint> cPointList, string shpPath)
        {
            int index = shpPath.LastIndexOf("\\");
            int EIndex = shpPath.LastIndexOf(".");
            string folder = shpPath.Substring(0, index);
            string shapeName = shpPath.Substring(index + 1, shpPath.Length - EIndex - 1);
            IWorkspaceFactory pWSF = new ShapefileWorkspaceFactoryClass();
            IFeatureWorkspace pFWS = (IFeatureWorkspace)pWSF.OpenFromFile(folder, 0);
            IFields pFields = new FieldsClass();
            IFieldsEdit pFieldsEdit;
            pFieldsEdit = (IFieldsEdit)pFields;
            IField pField = new FieldClass();
            IFieldEdit pFieldEdit = (IFieldEdit)pField;
            pFieldEdit.Name_2 = "Shape";
            pFieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
            IGeometryDef pGeometryDef = new GeometryDefClass();
            IGeometryDefEdit pGDefEdit = (IGeometryDefEdit)pGeometryDef;
            pGDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;
            //定义坐标系
            ISpatialReferenceFactory pSRF = new SpatialReferenceEnvironmentClass();
            ISpatialReference pSpatialReference = pSRF.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_WGS1984);
            pGDefEdit.SpatialReference_2 = pSpatialReference;

            pFieldEdit.GeometryDef_2 = pGeometryDef;
            pFieldsEdit.AddField(pField);

            IFeatureClass pFeatureClass;
            pFeatureClass = pFWS.CreateFeatureClass(shapeName, pFields, null, null, esriFeatureType.esriFTSimple, "Shape", "");

            IPoint pPoint = new PointClass();

            FormRuntime rtime = new FormRuntime(cPointList.Count);
            rtime.Show();

            for (int j = 0; j < cPointList.Count; j++)
            {
                rtime.Go();
                pPoint.X = cPointList[j].lon;
                pPoint.Y = cPointList[j].lat;

                IFeature pFeature = pFeatureClass.CreateFeature();
                pFeature.Shape = pPoint;
                pFeature.Store();
            }
            rtime.Ok();

            IFeatureLayer pFeatureLayer = new FeatureLayerClass();
            pFeatureLayer.Name = shapeName;
            pFeatureLayer.FeatureClass = pFeatureClass;
            return pFeatureLayer;
        }
        public static void CreateShpFromCSV(string csvPath, string shpPath)
        {
            List<CPoint> pCPointList = GetPoints(csvPath);
            if (pCPointList == null)
                return;
            IFeatureLayer pFeatureLayer = CreateShpFromPoints(pCPointList, shpPath);
            m_pMapC2.AddLayer(pFeatureLayer);
        }

    }
}
