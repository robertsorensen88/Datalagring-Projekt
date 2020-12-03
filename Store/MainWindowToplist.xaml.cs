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
            int movie_skip_count = 0;
            int movie_take_count = 30;
            State.Movies = API.GetMovieSlice(movie_skip_count, movie_take_count);

            int column_count = MovieGrids.ColumnDefinitions.Count;

            int row_count = (int)Math.Ceiling((double)State.Movies.Count / (double)column_count);

            for (int y = 0; y < row_count; y++)
            {
                // Skapa en rad-definition f�r att best�mma hur h�g just denna raden �r.
                MovieGrids.RowDefinitions.Add(
                    new RowDefinition()
                    {
                        Height = new GridLength(140, GridUnitType.Pixel)
                    });

                // L�gga till en film i varje cell f�r en rad
                for (int x = 0; x < column_count; x++)
                {
                    // R�kna ut vilken film vi ska ploppa in h�rn�st utifr�n mina x,y koordinater
                    int i = y * column_count + x;
                    // Kolla s� att vi inte f�rs�ker fylla mer Grid celler �n vi har filmrecords.
                    if (i < State.Movies.Count)
                    {
                        // H�mta ett film record
                        var movie = State.Movies[i];

                        // F�rs�k att skapa en Image Controller(legobit) och
                        // placera den i r�tt Grid cell enl. x,y koordinaterna
                        // Skapa en Image som visar filmomslaget
                        var image = new Image()
                        {
                            Cursor = Cursors.Hand, // Visa en 'click me' hand n�r man hovrar �ver bilden
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Margin = new Thickness(4, 4, 4, 4),
                        };
                        

                        try
                        {
                            image.Source = new BitmapImage(new Uri(movie.ImageURL)); // H�mta hem bildl�nken till RAM
                        }
                        catch (Exception e) when (e is ArgumentNullException || e is System.IO.FileNotFoundException || e is UriFormatException)
                        {
                            // Om n�got gick fel s� l�gger vi in en placeholder 
                            image.Source = new BitmapImage(new Uri(@"Assets\image-placeholder.jpg"));
                        }

                        // L�gg till Image i Grid
                        MenuBar.Children.Add(image);

                        // Placera in Image i Grid
                        Grid.SetRow(image, y);
                        Grid.SetColumn(image, x);
                    }
                }

            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var x = Grid.GetColumn(sender as UIElement);
            var y = Grid.GetRow(sender as UIElement);

            int i = y * MovieGrids.ColumnDefinitions.Count + x;
            State.Pick = State.Movies[i];

            if (API.RegisterSale(State.User, State.Pick))
                MessageBox.Show("All is well and you can download your movie now.", "Sale Succeeded!", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("An error happened while buying the movie, please try again at a later time.", "Sale Failed!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void HomeClick(object sender, RoutedEventArgs e)
        {
            var next_window = new MainWindow();
            next_window.Show();
            this.Close();
        }

        private void MyAccClick(object sender, RoutedEventArgs e)
        {
            var next_window = new MyAccountWindow();
            next_window.Show();
            this.Close();
        }

        private void GenreClick(object sender, RoutedEventArgs e)
        {
            var next_window = new GenreWindow();
            next_window.Show();
            this.Close();
        }

        private void LogoutClick(object sender, RoutedEventArgs e)
        {
            var next_window = new LoginWindow();
            next_window.Show();
            this.Close();
        }
    }
}
