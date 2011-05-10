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

using Data = TransportModel.Data;

namespace TransportModel
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Data.TransportModelRepository repository = null;

        public MainWindow()
        {
            InitializeComponent();
            repository = new TransportModel.Data.TransportModelRepository();
            this.Frame1.Navigate(new MainMenu(this));
        }
    }
}
