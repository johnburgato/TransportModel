using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Forms;
using System.ComponentModel;

using ProjNet;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using ProjNet.Converters;

using TransportModel;

namespace TransportModel
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public class ViewModel : INotifyPropertyChanged
        {
            private bool canSave = false;
            public bool CanSave
            {
                get
                {
                    return canSave;
                }

                set
                {
                    canSave = value;
                    OnPropertyChanged("CanSave");
                }
            }

            private bool canRun = false;
            public bool CanRun
            {
                get
                {
                    return canRun;
                }

                set
                {
                    canRun = value;
                    OnPropertyChanged("CanRun");
                }
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
        
        private MainWindow ParentWindow { get; set; }
        public ViewModel VM { get; set; }

        public MainMenu(MainWindow parent)
        {
            InitializeComponent();
            ParentWindow = parent;
            this.DataContext = this.VM = new ViewModel();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            ParentWindow.Close();
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            ParentWindow.Frame1.Navigate(new Import(this.ParentWindow));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveModelDlg = new SaveFileDialog();
                saveModelDlg.Filter = "Data File|*.dat";
                saveModelDlg.Title = "Save Model";
                saveModelDlg.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if (saveModelDlg.FileName != "")
                {
                    FileIOHelper.saveObject(saveModelDlg.FileName, ParentWindow.repository.GetModel());
                }

                this.VM.CanRun = true;

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (ParentWindow.repository.GetModel() != null)
            {
                this.VM.CanSave = true;
                this.VM.CanRun = true;
            }
            else
            {
                this.VM.CanSave = false;
                this.VM.CanRun = false;
            }
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            /*CoordinateSystemFactory c = new CoordinateSystemFactory();
            ICoordinateSystem source = c.CreateFromWkt("PROJCS[\"OSGB 1936 / British National Grid\",GEOGCS[\"OSGB 1936\",DATUM[\"OSGB_1936\",SPHEROID[\"Airy 1830\",6377563.396,299.3249646,AUTHORITY[\"EPSG\",\"7001\"]],AUTHORITY[\"EPSG\",\"6277\"]],PRIMEM[\"Greenwich\",0,AUTHORITY[\"EPSG\",\"8901\"]],UNIT[\"degree\",0.01745329251994328,AUTHORITY[\"EPSG\",\"9122\"]],AUTHORITY[\"EPSG\",\"4277\"]],PROJECTION[\"Transverse_Mercator\"],PARAMETER[\"latitude_of_origin\",49],PARAMETER[\"central_meridian\",-2],PARAMETER[\"scale_factor\",0.9996012717],PARAMETER[\"false_easting\",400000],PARAMETER[\"false_northing\",-100000],UNIT[\"metre\",1,AUTHORITY[\"EPSG\",\"9001\"]],AUTHORITY[\"EPSG\",\"27700\"]]");
            ICoordinateSystem target = c.CreateFromWkt("GEOGCS[\"GCS_WGS_1984\",DATUM[\"D_WGS_1984\",SPHEROID[\"WGS_1984\",6378137,298.257223563]],PRIMEM[\"Greenwich\",0],UNIT[\"Degree\",0.0174532925199433]]");


            CoordinateTransformationFactory trf = new CoordinateTransformationFactory();
            ICoordinateTransformation tr = trf.CreateFromCoordinateSystems(source, target);

            //http://projnet.codeplex.com/discussions/234481
            //486793,149328
            double[] point = new double[] { 486793, 149328 };
            double[] result = tr.MathTransform.Transform(point);

            System.Windows.MessageBox.Show("Converted 486793,149328 to " + result[0] + "," + result[1]);*/

            TransportModel.Model.Coordinate ne = new TransportModel.Model.Coordinate(486793, 149328);
            TransportModel.Model.Coordinate ll = TransportModel.Model.Projections.Instance.ConvertOsgbToWgs(ne);
            System.Windows.MessageBox.Show("Converted 486793,149328 to " + ll.X + "," + ll.Y);
        }
    }
}
