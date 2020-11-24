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
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    /// TODO Password and username have 2 match 2 login 
    public partial class LoginWindow : Window
    {
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public LoginWindow()
        {
            InitializeComponent();
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
        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            
            State.User = API.GetCustomerByName(NameField.Text.Trim());
            if (State.User != null)
            {
                var next_window = new MainWindow();
                next_window.Show();
                this.Close();
            }
            else
            {
                NameField.Text = "...";
            }
        }

        private void Button_GotMouseCapture(object sender, MouseEventArgs e)
        {

        }

        private void Button_GotMouseCapture_1(object sender, MouseEventArgs e)
        {

        }
    }
}
