using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportModel.Model
{
    [Serializable]
    public class OSSquare
    {
        private const int MAX_EASTINGS = 10000;

        public int BLEastings;
        public int BLNorthings;

        public OSSquare(int blE, int blN)
        {
            this.BLEastings = blE;
            this.BLNorthings = blN;
        }

        public int GetHash()
        {
            return (BLNorthings * MAX_EASTINGS) + BLEastings;
        }
    }
}
