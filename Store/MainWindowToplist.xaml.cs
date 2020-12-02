using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DatabaseConnection;

namespace Store
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowToplist : Window
    {

        public MainWindowToplist()
        {
            InitializeComponent();
        }

        private void HomeClick(object sender, RoutedEventArgs e)
        {
            var next_window = new MainWindow();
            next_window.Show();
            this.Close();
        }
    }
}
