using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;

using Model = TransportModel.Model;

namespace TransportModel.Data
{
    public class TransportModelRepository
    {
        private BackgroundWorker worker;
        private ImportWorker ImportWorker { get; set; }

        private RoadNetworkDataContext rnDc = null;
        protected RoadNetworkDataContext RNDataContext
        {
            get
            {
                if (rnDc == null)
                {
                    rnDc = new RoadNetworkDataContext();
                }
                return rnDc;
            }

        }

        public void ImportNetworkData(ref ImportPageViewModel info)
        {
            worker = new BackgroundWorker();
            ImportWorker = new ImportWorker(ref info, worker, RNDataContext);

            info.MaxRecords = 1000;
            info.OnPropertyChanged("MaxRecords");

            worker.DoWork += new DoWorkEventHandler(ImportWorker.DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ImportWorker.RunWorkerCompleted);
            worker.WorkerSupportsCancellation = true;

            worker.RunWorkerAsync();
        }

        public void CancelImportNetworkData()
        {
            if (worker != null && worker.IsBusy)
            {
                worker.CancelAsync();
            }
        }

        public int GetNodeCount(ref ImportPageViewModel info)
        {
            int c = (from n in RNDataContext.Nodes
                     select n).Count();

            info.InfoText = "Chopper " + c;
            info.OnPropertyChanged("InfoText");
            

            return c;
        }

        public Model.Model GetModel()
        {
            if (ImportWorker != null)
            {
                return ImportWorker.Model;
            }
            else
            {
                return null;
            }
        }
    }
}
