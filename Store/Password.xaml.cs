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
    public partial class Password : Window
    {
        public Password()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var next_window = new LoginWindow();
            next_window.Show();
            this.Close();
        }
        private void Password_Click(object sender, RoutedEventArgs e)
        {
            var next_window = new Password();
            
            try
            {
                next_window.Show();
                this.Close();
            }
            catch
            {
                Close();
                MessageBox.Show("Sure", "Some Title");
            }
        }
    }
}
