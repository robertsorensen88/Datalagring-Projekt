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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            State.Movies = API.GetMovieSlice(0, 30);
            for (int y = 0; y < MovieGrid.RowDefinitions.Count; y++)
            {
                for (int x = 0; x < MovieGrid.ColumnDefinitions.Count; x++)
                {
                    int i = y * MovieGrid.ColumnDefinitions.Count + x;
                    if (i < State.Movies.Count)
                    {
                        var movie = State.Movies[i];

                        try
                        {
                            var image = new Image() { };
                            image.Cursor = Cursors.Hand;
                            image.MouseUp += Image_MouseUp;
                            image.HorizontalAlignment = HorizontalAlignment.Center;
                            image.VerticalAlignment = VerticalAlignment.Center;
                            image.Source = new BitmapImage(new Uri(movie.ImageURL));
                            //image.Height = 120;
                            image.Margin = new Thickness(4, 4, 4, 4);

                            MovieGrid.Children.Add(image);
                            Grid.SetRow(image, y);
                            Grid.SetColumn(image, x);
                        }
                        catch (Exception e) when 
                            (e is ArgumentNullException || 
                             e is System.IO.FileNotFoundException || 
                             e is UriFormatException)
                        {
                            continue;
                        }
                    }
                }
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var x = Grid.GetColumn(sender as UIElement);
            var y = Grid.GetRow(sender as UIElement);

            int i = y * MovieGrid.ColumnDefinitions.Count + x;
            State.Pick = State.Movies[i];

            if(API.RegisterSale(State.User, State.Pick))
                MessageBox.Show("All is well and you can download your movie now.", "Sale Succeeded!", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("An error happened while buying the movie, please try again at a later time.", "Sale Failed!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Menu_Button.IsChecked == true)
            {
                tt_filter.Visibility = Visibility.Collapsed;
                tt_info.Visibility = Visibility.Collapsed;
                tt_settings.Visibility = Visibility.Collapsed;
                tt_back.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_filter.Visibility = Visibility.Visible;
                tt_info.Visibility = Visibility.Visible;
                tt_settings.Visibility = Visibility.Visible;
                tt_back.Visibility = Visibility.Visible;
            }
        }

        private void Menu_Button_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.2;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Menu_Button.IsChecked = false;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
