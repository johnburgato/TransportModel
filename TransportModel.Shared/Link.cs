using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportModel.Model
{
    [Serializable]
    public class Link
    {
        public class AccessType
        {
            public byte PEDESTRIAN = 0x01;
            public byte CYCLE = 0x02;
            public byte CAR = 0x04;
        }

        public int Id { get; set; }
        public List<Link> AttachedLinks { get; set; }
        public Node StartNode { get; set; }
        public Node EndNode { get; set; }

        public double? Length { get; set; }
        //public int? SpeedLimit { get; set; }
        public long? Attributes { get; set; }

        public List<Coordinate> PolylineLatLon { get; set; }
        public List<Coordinate> PolylineNorEst { get; set; }

        public Link(int id, double? length, long? attr, string polyLine)
        {
            Id = id;
            Length = length;
            Attributes = attr;
            AttachedLinks = new List<Link>();
            //463833,1213523 463817,1213525 463794,1213530 463772,1213538 463764,1213543 463732,1213566 463701,1213591 463694,1213599 463689,1213605 463683,1213618 463664,1213679 463660,1213691 463658,1213694 463655,1213697 463652,1213700 463648,1213702 463637,1213704 463621,1213703 463538,1213687 463518,1213684 463510,1213685 463505,1213687 463500,1213692 463480,1213710 463475,1213717 463473,1213722 463470,1213729 463468,1213739 463466,1213753 463465,1213767 463465,1213770 463464,1213795 463467,1213835 463476,1213898 463476,1213900

            if (!string.IsNullOrEmpty(polyLine))
            {
                PolylineLatLon = new List<Coordinate>();
                PolylineNorEst = new List<Coordinate>();
                string[] pairs = polyLine.Split(' ');

                foreach (string pair in pairs)
                {
                    string[] osgbStr = pair.Split(',');
                    double e = double.Parse(osgbStr[0]);
                    double n = double.Parse(osgbStr[1]);

                    Coordinate eastNor = new Coordinate(e, n);
                    PolylineNorEst.Add(eastNor);
                    Coordinate lonLat = Projections.Instance.ConvertOsgbToWgs(eastNor);
                    PolylineLatLon.Add(lonLat);
                }
            }

        }
    }
}
