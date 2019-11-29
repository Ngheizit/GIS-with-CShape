using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;

namespace TianDiTuPOI
{
    class AeUtils
    {
        private static IMapControl2 m_pMapC2;
        public static void SetMapControl(IMapControl2 mapControl)
        {
            m_pMapC2 = mapControl;
        }

        public static IRgbColor CreateRgbColor(byte r, byte g, byte b, byte a = 255)
        {
            return new RgbColorClass() { 
                Red = r,
                Green = g,
                Blue = b,
                Transparency = a,
                UseWindowsDithering = true
            };
        }

        public static void DrawEnvelope(IEnvelope envelope)
        {
            IGraphicsContainer pGC = m_pMapC2.Map as IGraphicsContainer;
            pGC.DeleteAllElements();
            IElement pElement = new RectangleElementClass() { 
                Geometry = envelope,
                Symbol = new SimpleFillSymbolClass(){
                    Color = CreateRgbColor(0, 0, 0, 0),
                    Outline = new SimpleLineSymbolClass(){
                        Color = CreateRgbColor(255, 0, 0),
                        Width = 2
                    }
                }
            };
            pGC.AddElement(pElement, 0);
            m_pMapC2.Refresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
    }
}
