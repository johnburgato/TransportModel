﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportModel.Model
{
    [Serializable]
    public class Node
    {
        public List<Link> Links { get; set; }

        public int Id { get; set; }
        public int? Eastings { get; set; }
        public int? Northigns { get; set; }

        public Node(int id, int? eastings, int? northings)
        {
            Id = id;
            Eastings = eastings;
            Northigns = northings;
            Links = new List<Link>();
        }
    }
}
