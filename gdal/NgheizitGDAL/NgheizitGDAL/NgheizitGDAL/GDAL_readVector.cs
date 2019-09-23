using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using OSGeo.OGR;

namespace NgheizitGDAL
{
    class GDAL_readVector
    {
        public static string GetVectorInfo(string strFilePath)
        {
            string strInfomation = "";
            Ogr.RegisterAll();
            DataSource ds = Ogr.Open(strFilePath, 0);
            if(ds == null)
            {
                strInfomation = "Can't open" + strFilePath;
                return strInfomation;
            }
            Driver drv = ds.GetDriver();
            if(drv == null)
            {
                strInfomation = "Can't get driver";
                return strInfomation;
            }
            strInfomation += "Using driver" + drv.name;
            for (int iLayer = 0; iLayer < ds.GetLayerCount(); iLayer++)
            {
                Layer layer = ds.GetLayerByIndex(iLayer);
                if(layer == null)
                {
                    strInfomation = "FAILURE: Couldn't fetch advertised layer" + iLayer;
                    return strInfomation;
                }
                strInfomation += ReportLayer(layer);
            }
            return strInfomation;
        }

        public static string ReportLayer(Layer layer)
        {
            string strInfomation = "";
            FeatureDefn def = layer.GetLayerDefn();
            strInfomation += "Layer name: " + def.GetName();
            strInfomation += "Feature count: " + layer.GetFeatureCount(1).ToString();
            Envelope ext = new Envelope();
            layer.GetExtent(ext, 1);
            strInfomation += "Extent: " + ext.MinX.ToString() + "," + ext.MaxX.ToString()
                                        + ext.MinY.ToString() + "," + ext.MaxY.ToString();
            OSGeo.OSR.SpatialReference sr = layer.GetSpatialRef();
            string srs_wkt;
            if(sr != null)
            {
                sr.ExportToPrettyWkt(out srs_wkt, 1);
            }
            else
            {
                srs_wkt = "unKononw";
            }
            strInfomation += "Layer SRS WKT: " + srs_wkt;
            strInfomation += "Field definition: ";
            for (int iAttr = 0; iAttr < def.GetFieldCount(); iAttr++)
            {
                FieldDefn fdef = def.GetFieldDefn(iAttr);
                strInfomation += fdef.GetNameRef() + ":" +
                                 fdef.GetFieldTypeName(fdef.GetFieldType()) + " (" +
                                 fdef.GetWidth().ToString() + "." +
                                 fdef.GetPrecision().ToString() + ")";
            }
            strInfomation += "";
            Feature feat;
            while((feat = layer.GetNextFeature()) != null)
            {
                strInfomation += ReportFeature(feat, def);
                feat.Dispose();
            }
            return strInfomation;
        }

        public static string ReportFeature(Feature feat, FeatureDefn def)
        {
            string strInfomation = "";
            strInfomation += "Feature(" + def.GetName() + "):" + feat.GetFID().ToString();
            for (int iField = 0; iField < feat.GetFieldCount(); iField++)
            {
                FieldDefn fdef = def.GetFieldDefn(iField);
                strInfomation += fdef.GetNameRef() + "(" +
                                 fdef.GetFieldTypeName(fdef.GetFieldType()) + ") = ";
                if (feat.IsFieldSet(iField))
                {
                    if (fdef.GetFieldType() == FieldType.OFTStringList)
                    {
                        string[] sList = feat.GetFieldAsStringList(iField);
                        foreach (string s in sList)
                        {
                            strInfomation += "\"" + s + "\"";
                        }
                        strInfomation += "\n";
                    }
                    else if (fdef.GetFieldType() == FieldType.OFTIntegerList)
                    {
                        int count;
                        int[] iList = feat.GetFieldAsIntegerList(iField, out count);
                        for (int i = 0; i < count; i++)
                        {
                            strInfomation += (iList[i] + " ");
                        }
                        strInfomation += ("\n");
                    }

                    else if (fdef.GetFieldType() == FieldType.OFTRealList)
                    {
                        int count;
                        double[] iList = feat.GetFieldAsDoubleList(iField, out count);
                        for (int i = 0; i < count; i++)
                        {
                            strInfomation += (iList[i].ToString() + " ");
                        }
                        strInfomation += ("\n");
                    }
                    else
                        strInfomation += (feat.GetFieldAsString(iField));
                }
                else
                    strInfomation += "null";
            }
            Geometry geom = feat.GetGeometryRef();
            if(geom != null)
            {
                strInfomation += "  " + geom.GetGeometryName() +
                                 "(" + geom.GetGeometryType() + ")";
                Geometry sub_geom;
                for(int i = 0; i < geom.GetGeometryCount(); i++)
                {
                    sub_geom = geom.GetGeometryRef(i);
                    if(sub_geom != null)
                    {
                        strInfomation += " subgeom" + i + ": " + sub_geom.GetGeometryName() +
                                         "(" + sub_geom.GetGeometryType() + ")";
                    }
                }
                Envelope env = new Envelope();
                geom.GetEnvelope(env);
                strInfomation += "  ENVELOP: " + env.MinX + "," + env.MaxX + "," +
                                                 env.MinY + "," + env.MaxY;
                string geom_wkt;
                geom.ExportToWkt(out geom_wkt);
                strInfomation += "  " + geom_wkt;
            }
            strInfomation += "\n";
            return strInfomation;
        }
    }
}
