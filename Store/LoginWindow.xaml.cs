using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DatabaseConnection;

namespace Store
{
 
    public partial class LoginWindow : Window
    {
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public LoginWindow()
        {
            InitializeComponent();
            NameField.Text = "...";
            PasswordField.Password = "...";
        }

        private void SignUp_Click(Object sender, RoutedEventArgs e)
        {
            var next_window = new CreateUser();
            try
            {
                next_window.Show();
                this.Close();
            }
            catch
            {
                this.Close();
            }
        }
        private void Password_Click(object sender, RoutedEventArgs e)
        {
            var next_window = new Password();
            next_window.Show();
            this.Close();
        }
        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            
            // TODO en Forloop som rullar igenom customer listan. matchar lösen och user.
            State.User = API.GetCustomerByName(NameField.Text.Trim());
            if (State.User.Username != null)
            {
                if (State.User.Password == PasswordField.Password)
                {

                    var next_window = new MainWindow();
                    next_window.Show();
                    this.Close();
                }
                else
                {
                    PasswordField.Password = "...";
                    MessageBox.Show("Wrong password. Try Again!", "Wrong password", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

            }
            else
            {
                NameField.Text = "...";
                MessageBox.Show("Wrong username. Try again!", "Wrong username", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            
        }
        private void UsernameClickEvent(object sender, MouseButtonEventArgs e)
        {
            NameField.Clear();
        }
        private void PasswordClickEvent(object sender, MouseButtonEventArgs e)
        {
            PasswordField.Clear();
        }
        private void Button_GotMouseCapture(object sender, MouseEventArgs e)
        {

        }

        private void Button_GotMouseCapture_1(object sender, MouseEventArgs e)
        {

        }
    }
}
