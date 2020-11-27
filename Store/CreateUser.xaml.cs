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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    /// TODO Password and username have 2 match 2 login 
    public partial class CreateUser : Window
    {
        public CreateUser()
        {
            InitializeComponent();
        }
        private void ReturnButtonClick(object sender, RoutedEventArgs e)
        {
            var next_window = new LoginWindow();
            next_window.Show();
            this.Close();
        }
        
       /* private void CreateUser_Click(object sender, RoutedEventArgs e)
        {
            if (NewPasswordbox == CPasswordbox)
            {
                Customer.Add 

                var next_window = new LoginWindow();
                next_window.Show();
                this.Close();
            }
        }*/
    }
    
}