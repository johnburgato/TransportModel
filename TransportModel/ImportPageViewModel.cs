using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;

namespace TransportModel
{
    public class ImportPageViewModel : INotifyPropertyChanged
    {
        public int? EastingsMin { get; set; }
        public int? EastingsMax { get; set; }
        public int? NorthingsMin { get; set; }
        public int? NorthingsMax { get; set; }
        public bool CanImport { get; set; }
        public string InfoText { get; set; }
        public bool Error { get; set; }

        public int RecordNumber { get; set; }
        public int MaxRecords { get; set; }

        public ImportPageViewModel()
        {
            RecordNumber = 0;
            MaxRecords = 1;
            //486793,149328 
            EastingsMin = 486000000; EastingsMax = 486999999;
            NorthingsMin = 149000000; NorthingsMax = 149999999;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
