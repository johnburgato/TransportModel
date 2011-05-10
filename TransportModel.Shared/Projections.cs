using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjNet;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using ProjNet.Converters;

namespace TransportModel.Model
{
    public class Projections
    {
        private static Projections instance = null;
        public static Projections Instance {
            get
            {
                if (instance == null)
                {
                    instance = new Projections();
                }

                return instance;
            }
        }

        private ICoordinateTransformation OsgbToWgs { get; set; }
        private ICoordinateTransformation WgsToOsgb { get; set; }

        public Projections()
        {
            CoordinateSystemFactory c = new CoordinateSystemFactory();
            ICoordinateSystem osgb = c.CreateFromWkt("PROJCS[\"OSGB 1936 / British National Grid\",GEOGCS[\"OSGB 1936\",DATUM[\"OSGB_1936\",SPHEROID[\"Airy 1830\",6377563.396,299.3249646,AUTHORITY[\"EPSG\",\"7001\"]],AUTHORITY[\"EPSG\",\"6277\"]],PRIMEM[\"Greenwich\",0,AUTHORITY[\"EPSG\",\"8901\"]],UNIT[\"degree\",0.01745329251994328,AUTHORITY[\"EPSG\",\"9122\"]],AUTHORITY[\"EPSG\",\"4277\"]],PROJECTION[\"Transverse_Mercator\"],PARAMETER[\"latitude_of_origin\",49],PARAMETER[\"central_meridian\",-2],PARAMETER[\"scale_factor\",0.9996012717],PARAMETER[\"false_easting\",400000],PARAMETER[\"false_northing\",-100000],UNIT[\"metre\",1,AUTHORITY[\"EPSG\",\"9001\"]],AUTHORITY[\"EPSG\",\"27700\"]]");
            ICoordinateSystem wgs = c.CreateFromWkt("GEOGCS[\"GCS_WGS_1984\",DATUM[\"D_WGS_1984\",SPHEROID[\"WGS_1984\",6378137,298.257223563]],PRIMEM[\"Greenwich\",0],UNIT[\"Degree\",0.0174532925199433]]");

            CoordinateTransformationFactory trf = new CoordinateTransformationFactory();
            this.OsgbToWgs = trf.CreateFromCoordinateSystems(osgb, wgs);
            this.WgsToOsgb = trf.CreateFromCoordinateSystems(wgs, osgb);
        }

        public Coordinate ConvertOsgbToWgs(Coordinate ne)
        {
            return Convert(ne, this.OsgbToWgs);
        }

        public Coordinate ConvertWgsToOsgb(Coordinate ll)
        {
            return Convert(ll, this.WgsToOsgb);
        }

        private Coordinate Convert(Coordinate a, ICoordinateTransformation tx)
        {
            double[] point = new double[] { a.X, a.Y };
            double[] result = tx.MathTransform.Transform(point);

            return new Coordinate(result[0], result[1]);
        }

    }
}
