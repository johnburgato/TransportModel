using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportModel.Model
{
    [Serializable]
    public class Model
    {
        //private Dictionary<int, List<Node>> SquareNodeLookup;

        public Dictionary<int, Node> AllNodes; // key = id
        public Dictionary<int, Link> AllLinks; // key = id
        public List<Attribute> Attributes { get; set; }

        public List<Link> GetLinksFrom(int linkId)
        {
            return null;
        }

        public List<Node> GetNearbyNodes(int eastings, int northings)
        {
            return null;
        }

        public List<Link> GetAllLinks()
        {
            return AllLinks.Values.ToList();
        }

        public Model()
        {
            AllNodes = new Dictionary<int, Node>();
            AllLinks = new Dictionary<int, Link>();
            Attributes = new List<Attribute>();
        }
    }
}
