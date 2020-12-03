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
            State.User = API.GetCustomerByName(NameField.Text.Trim());
            if (State.User.Username != null)
            {
                if (PasswordField.Password == State.User.Password)
                {
                    if (NewPasswordField.Password == CNewPasswordField.Password)
                    {
                        State.User.Password = NewPasswordField.Password;
                        API.ctx.Customers.Update(State.User);
                        API.ctx.SaveChanges();
                        MessageBox.Show("Successfully changed password", "Password Changed", MessageBoxButton.OK, MessageBoxImage.Information);
                        var next_window = new LoginWindow();
                        next_window.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("New password not matching", "Password Error", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Existing Password", "Password Error", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                NameField.Text = "...";
                MessageBox.Show("Wrong username. Try again!", "Wrong username", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
