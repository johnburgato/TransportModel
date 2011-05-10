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

using System.ComponentModel;


namespace TransportModel
{
    /// <summary>
    /// Interaction logic for Import.xaml
    /// </summary>
    public partial class Import : Page
    {
        private ImportPageViewModel VieiwModel;
        private MainWindow ParentWindow { get; set; }

        public Import(MainWindow parent)
        {
            InitializeComponent();
            ParentWindow = parent;
            this.DataContext = this.VieiwModel = new ImportPageViewModel();
            this.VieiwModel.CanImport = true;
            
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VieiwModel.Error = false;
                ParentWindow.repository.ImportNetworkData(ref VieiwModel);
            }
            catch (Exception ex)
            {
                VieiwModel.InfoText = ex.StackTrace;
                VieiwModel.Error = true;
            }
        }

        private void btnCancelImport_Click(object sender, RoutedEventArgs e)
        {
            if (ParentWindow.repository != null)
            {
                ParentWindow.repository.CancelImportNetworkData();
            }
        }
    }
}
