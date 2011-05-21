using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using ProjNet;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using ProjNet.Converters;

using Data = TransportModel.Data;
using Mem = TransportModel.Model;

namespace TransportModel.Data
{
    public class ImportWorker
    {
        private ImportPageViewModel info = null;
        private BackgroundWorker worker = null;
        private RoadNetworkDataContext DataContext { get; set; }
        private ICoordinateTransformation OsgbToWgs { get; set; }

        public Mem.Model Model { get; set; }

        public ImportWorker(ref ImportPageViewModel infoRef, BackgroundWorker bgWorker, RoadNetworkDataContext dc)
        {
            info = infoRef;
            worker = bgWorker;
            DataContext = dc;

            CoordinateSystemFactory c = new CoordinateSystemFactory();
            ICoordinateSystem source = c.CreateFromWkt("PROJCS[\"OSGB 1936 / British National Grid\",GEOGCS[\"OSGB 1936\",DATUM[\"OSGB_1936\",SPHEROID[\"Airy 1830\",6377563.396,299.3249646,AUTHORITY[\"EPSG\",\"7001\"]],AUTHORITY[\"EPSG\",\"6277\"]],PRIMEM[\"Greenwich\",0,AUTHORITY[\"EPSG\",\"8901\"]],UNIT[\"degree\",0.01745329251994328,AUTHORITY[\"EPSG\",\"9122\"]],AUTHORITY[\"EPSG\",\"4277\"]],PROJECTION[\"Transverse_Mercator\"],PARAMETER[\"latitude_of_origin\",49],PARAMETER[\"central_meridian\",-2],PARAMETER[\"scale_factor\",0.9996012717],PARAMETER[\"false_easting\",400000],PARAMETER[\"false_northing\",-100000],UNIT[\"metre\",1,AUTHORITY[\"EPSG\",\"9001\"]],AUTHORITY[\"EPSG\",\"27700\"]]");
            ICoordinateSystem target = c.CreateFromWkt("GEOGCS[\"GCS_WGS_1984\",DATUM[\"D_WGS_1984\",SPHEROID[\"WGS_1984\",6378137,298.257223563]],PRIMEM[\"Greenwich\",0],UNIT[\"Degree\",0.0174532925199433]]");
            CoordinateTransformationFactory trf = new CoordinateTransformationFactory();
            OsgbToWgs = trf.CreateFromCoordinateSystems(source, target);
        }

        public void DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                info.InfoText = "Calculating";
                info.OnPropertyChanged("InfoText");
                info.CanImport = false;
                info.OnPropertyChanged("CanImport");

                IQueryable<Data.Node> nodeQuery = (from n in DataContext.Nodes
                                                   select n);

                
                #region Limit query
                if (info.EastingsMin.HasValue)
                {
                    nodeQuery = (from n in nodeQuery
                                 where n.Easting > info.EastingsMin
                                 select n);
                }

                if (info.EastingsMax.HasValue)
                {
                    nodeQuery = (from n in nodeQuery
                                 where n.Easting < info.EastingsMax
                                 select n);
                }

                if (info.NorthingsMin.HasValue)
                {
                    nodeQuery = (from n in nodeQuery
                                 where n.Northing > info.NorthingsMin
                                 select n);
                }

                if (info.NorthingsMax.HasValue)
                {
                    nodeQuery = (from n in nodeQuery
                                 where n.Northing < info.NorthingsMax
                                 select n);
                }
                #endregion

                IQueryable<Data.Link> linkQuery = (from l in DataContext.Links
                                                   from n in nodeQuery
                                                   where l.ANode == n.ID || l.BNode == n.ID
                                                   select l).Distinct();

                int nodeNo = nodeQuery.Count();
                int linkNo = linkQuery.Count();
                info.MaxRecords = nodeNo + linkNo;
                info.InfoText = "Nodes: " + nodeNo + ", Links: " + linkNo + Environment.NewLine;
                info.OnPropertyChanged("MaxRecords");
                info.OnPropertyChanged("InfoText");

                Model = new TransportModel.Model.Model();

                info.InfoText += "Loading nodes" + Environment.NewLine;
                info.OnPropertyChanged("InfoText");

                foreach (Data.Node n in nodeQuery)
                {
                    if (CheckForCancellation(this.worker, e)) return;
                    Mem.Node memNode = new TransportModel.Model.Node(n.ID, n.Easting, n.Northing);
                    Model.AllNodes.Add(n.ID, memNode);

                    info.RecordNumber++;
                    info.OnPropertyChanged("RecordNumber");
                }

                info.InfoText += "Loading links" + Environment.NewLine;
                info.OnPropertyChanged("InfoText");

                foreach (Data.Link l in linkQuery)
                {
                    if (CheckForCancellation(this.worker, e)) return;
                    Mem.Link link = new TransportModel.Model.Link(l.ID, l.Length, l.Attributes, l.Polyline);

                    if (l.ANode.HasValue && Model.AllNodes.ContainsKey(l.ANode.Value))
                    {
                        link.StartNode = Model.AllNodes[l.ANode.Value];
                        if (link.StartNode != null)
                        {
                            link.StartNode.Links.Add(link);
                        }
                    }

                    if (l.BNode.HasValue && Model.AllNodes.ContainsKey(l.BNode.Value))
                    {
                        link.EndNode = Model.AllNodes[l.BNode.Value];
                        if (link.EndNode != null)
                        {
                            link.EndNode.Links.Add(link);
                        }
                    }

                    if (!Model.AllLinks.ContainsKey(l.ID))
                    {
                        Model.AllLinks.Add(l.ID, link);
                    }
                    else
                    {
                        info.InfoText += "Link id " + l.ID + " already used" + Environment.NewLine;
                        info.OnPropertyChanged("InfoText");
                    }

                    info.RecordNumber++;
                    info.OnPropertyChanged("RecordNumber");
                }

                info.InfoText += "Linking links" + Environment.NewLine;
                info.OnPropertyChanged("InfoText");

                ProjNet.CoordinateSystems.GeographicCoordinateSystem a = ProjNet.CoordinateSystems.GeographicCoordinateSystem.WGS84;

                foreach (Mem.Link lnk in Model.AllLinks.Values)
                {
                    LinkNodeLinks(lnk, lnk.StartNode);
                    LinkNodeLinks(lnk, lnk.EndNode);
                }

                info.InfoText += "Getting attributes" + Environment.NewLine;
                info.OnPropertyChanged("InfoText");

                List<Mem.Attribute> allAttributes = (from attr in DataContext.AttributeLists
                                                     select new Mem.Attribute(attr.name, attr.value, attr.node, attr.arrayindex, attr.ATOB_mask, attr.BTOA_mask)).ToList();

                Model.Attributes = allAttributes;
                
                info.InfoText += "Done" + Environment.NewLine;
                info.OnPropertyChanged("InfoText");

            }
            catch (Exception ex)
            {
                info.InfoText += "Problem!!!!!!!" + Environment.NewLine + ex.ToString() + Environment.NewLine + ex.StackTrace;
                info.OnPropertyChanged("InfoText");
            }
        }

        private void LinkNodeLinks(Mem.Link l, Mem.Node n)
        {
            if (n != null)
            {
                foreach (Mem.Link attLnk in n.Links)
                {
                    if (attLnk != l) // don't add ourselves
                    {
                        l.AttachedLinks.Add(attLnk);
                    }
                }
            }
        }

        public void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            info.CanImport = true;
            info.OnPropertyChanged("CanImport");
        }

        private bool CheckForCancellation(BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (worker.CancellationPending && !e.Cancel)
            {
                e.Cancel = true;
            }
            return e.Cancel;
        }
    }
}
