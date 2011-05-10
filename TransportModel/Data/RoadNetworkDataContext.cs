using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportModel.Data
{
    public partial class RoadNetworkDataContext : System.Data.Linq.DataContext
    {
        partial void OnCreated()
        {
            //Put your desired timeout here.
            this.CommandTimeout = 3600;

            //If you do not want to hard code it, then take it 
            //from Application Settings / AppSettings
            //this.CommandTimeout = Settings.Default.CommandTimeout;
        }
    }
}
