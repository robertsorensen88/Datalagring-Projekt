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
    public partial class GenreWindow : Window
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
        private void MyAccClick(object sender, RoutedEventArgs e)
        {
            var next_window = new MyAccountWindow();
            next_window.Show();
            this.Close();
        }
        public GenreWindow()
        {

            InitializeComponent();




        }

        private void ActionClick(object sender, RoutedEventArgs e)
        {
            var next_window = new ActionWindow();
            next_window.Show();
            this.Close();
        }

        private void AnimationClick(object sender, RoutedEventArgs e)
        {

        }

        private void AdventureClick(object sender, RoutedEventArgs e)
        {

        }

        private void BiograhphyClick(object sender, RoutedEventArgs e)
        {

        }

        private void ComedyClick(object sender, RoutedEventArgs e)
        {

        }

        private void CrimeClick(object sender, RoutedEventArgs e)
        {

        }

        private void DramaClick(object sender, RoutedEventArgs e)
        {

        }

        private void DocumentaryClick(object sender, RoutedEventArgs e)
        {

        }

        private void FantasyClick(object sender, RoutedEventArgs e)
        {

        }

        private void FamilyClick(object sender, RoutedEventArgs e)
        {

        }

        private void HorrorClick(object sender, RoutedEventArgs e)
        {

        }

        private void MusicClick(object sender, RoutedEventArgs e)
        {

        }

        private void RomanceClick(object sender, RoutedEventArgs e)
        {

        }

        private void ScifiClick(object sender, RoutedEventArgs e)
        {

        }

        private void ThrillerClick(object sender, RoutedEventArgs e)
        {

        }
    }
}