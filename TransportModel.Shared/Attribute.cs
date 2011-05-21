using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportModel.Model
{
    [Serializable]
    public class Attribute
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool Node { get; set; }
        public short ArrayIndex { get; set; }
        public long AToBMask { get; set; }
        public long BToAMask { get; set; }

        public Attribute(string name, string value, bool node, short arrayIndex, long aTob, long bToa)
        {
            Name = name;
            Value = value;
            Node = node;
            ArrayIndex = arrayIndex;
            AToBMask = aTob;
            BToAMask = bToa;
        }
    }
}
