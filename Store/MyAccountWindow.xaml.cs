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
    public partial class MyAccountWindow : Window
    {
        private void HomeClick(object sender, RoutedEventArgs e)
        {
            var next_window = new MainWindow();
            next_window.Show();
            this.Close();
        }
        private void ToplistClick(object sender, RoutedEventArgs e)
        {
            var next_window = new MainWindowToplist();
            next_window.Show();
            this.Close();

        }

        private void LogoutClick(object sender, RoutedEventArgs e)
        {
            var next_window = new LoginWindow();
            next_window.Show();
            this.Close();
        }
        public MyAccountWindow()
        {

            InitializeComponent();

            UserLabel.Content = State.User.Username;
            int GetId = State.User.Id;

            State.User.Sales = API.GetRentalSlice(GetId);

            for (int i = 0; i < State.User.Sales.Count; i++)
            {

                var rental = State.User.Sales[i];

                var RentalTitle = new Label() { };
                RentalTitle.Content = rental.Movie.Title;
                RentalTitle.HorizontalAlignment = HorizontalAlignment.Left;
                RentalTitle.VerticalAlignment = VerticalAlignment.Top;
                RentalTitle.Foreground = UserLabel.Foreground;

                RentList.Children.Add(RentalTitle);

            }

        }
              
    }  
}