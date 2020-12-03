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
        private void CreateUserClick(object sender, RoutedEventArgs e)
        {
            using (var ctx = new Context())
            {
                
                    
                if (Passwordbox.Password == CPasswordbox.Password)
                {

                    State.User = API.GetCustomerByName(Username.Text);
                    if (State.User != null)
                    {
                        MessageBox.Show("Username already taken.", "Account creation Failed!", MessageBoxButton.OK, MessageBoxImage.Information);
                        
                    }
                    else
                    {
                        ctx.Customers.Add(new Customer { FirstName = Firstname.Text, LastName = Lastname.Text, Password = Passwordbox.Password, Email = Email.Text, Username = Username.Text });
                        ctx.SaveChanges();

                        MessageBox.Show("Account successful creation.", "Account creation Succeeded!", MessageBoxButton.OK, MessageBoxImage.Information);
                        var next_window = new LoginWindow();
                        next_window.Show();
                        this.Close();
                    }
                }
                else
                {
                     Passwordbox.Background = Brushes.Red;
                     CPasswordbox.Background = Brushes.Red;
                     MessageBox.Show("Password doesn't match.", "Password error.", MessageBoxButton.OK, MessageBoxImage.Information);
                }
  
            }
        }
    }
    
}