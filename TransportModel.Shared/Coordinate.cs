using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportModel.Model
{
    [Serializable]
    public class Coordinate
    {
        public double X { get; set; } // eastings/longiture
        public double Y { get; set; } // northings/latitude
        public double Z { get; set; } // height

        public Coordinate(double x, double y)
        {
            X = x;
            Y = y;
            Z = 0;
        }
    }
}
