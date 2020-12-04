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

    public partial class ScifiWindow : Window
    {

        public ScifiWindow()
        {
            InitializeComponent();
            string cat = "Sci-Fi";

            State.Movies = API.GetMoviebyCategory(cat);

            int column_count = MovieGrid.ColumnDefinitions.Count;

            int row_count = (int)Math.Ceiling((double)State.Movies.Count / (double)column_count);

            for (int y = 0; y < row_count; y++)
            {
                // Skapa en rad-definition för att bestämma hur hög just denna raden är.
                MovieGrid.RowDefinitions.Add(
                    new RowDefinition()
                    {
                        Height = new GridLength(140, GridUnitType.Pixel)
                    });

                // Lägga till en film i varje cell för en rad
                for (int x = 0; x < column_count; x++)
                {
                    // Räkna ut vilken film vi ska ploppa in härnäst utifrån mina x,y koordinater
                    int i = y * column_count + x;
                    // Kolla så att vi inte försöker fylla mer Grid celler än vi har filmrecords.
                    if (i < 30)
                    {
                        // Hämta ett film record
                        var movie = State.Movies[i];


                        // Försök att skapa en Image Controller(legobit) och
                        // placera den i rätt Grid cell enl. x,y koordinaterna
                        // Skapa en Image som visar filmomslaget
                        try
                        {
                            var title = new Label() { }; // variabel för texten
                            title.Content = movie.Title; // Vad texten ska innehålla, i detta fall Movie.Title i databasen
                            title.HorizontalAlignment = HorizontalAlignment.Center; // vart texten ska ligga horisontelt
                            title.VerticalAlignment = VerticalAlignment.Top; // vart texten ska ligga vertikalt
                            title.FontSize = 10;
                            title.Foreground = HeadLabel.Foreground;
                            title.Margin = new Thickness(2, 20, 2, 2);

                            var image = new Image() { };
                            image.Cursor = Cursors.Hand; // om man håller över en bild blir det ett sånt pekfinger
                            image.MouseUp += Image_MouseUp; // Om man klickar på en bilden skickas man ner till Image_MouseUp Metoden.
                            image.HorizontalAlignment = HorizontalAlignment.Center;
                            image.VerticalAlignment = VerticalAlignment.Center;
                            image.Source = new BitmapImage(new Uri(movie.ImageURL)); // hämtar url från ImageURL i databasen till bilderna
                            image.Height = 60;
                            image.Width = 60;
                            image.Stretch = Stretch.Fill;


                            var rating = new Label() { };
                            rating.Content = movie.Rating + "/10 ";
                            rating.HorizontalAlignment = HorizontalAlignment.Center;
                            rating.VerticalAlignment = VerticalAlignment.Bottom;
                            rating.Foreground = HeadLabel.Foreground;
                            rating.FontSize = 10;
                            rating.Margin = new Thickness(2, 2, 2, 18);

                            var genre = new Label() { };
                            genre.Content = movie.Genre;
                            genre.HorizontalAlignment = HorizontalAlignment.Center;
                            genre.VerticalAlignment = VerticalAlignment.Bottom;
                            genre.Foreground = HeadLabel.Foreground;
                            genre.FontSize = 10;
                            genre.Margin = new Thickness(2, 2, 2, 7);



                            MovieGrid.Children.Add(title); // säger till att texten ska tillhöra den gridden
                            Grid.SetRow(title, y); // vilken grid i y
                            Grid.SetColumn(title, x); // vilken grid i x
                            MovieGrid.Children.Add(image);
                            Grid.SetRow(image, y);
                            Grid.SetColumn(image, x);
                            MovieGrid.Children.Add(rating);
                            Grid.SetRow(rating, y);
                            Grid.SetColumn(rating, x);
                            MovieGrid.Children.Add(genre);
                            Grid.SetRow(genre, y);
                            Grid.SetColumn(genre, x);
                        }
                        catch (Exception exeption) when
                            (exeption is ArgumentNullException ||
                             exeption is System.IO.FileNotFoundException ||
                             exeption is UriFormatException)
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

        private void ToplistClick(object sender, RoutedEventArgs e)
        {
            var next_window = new MainWindowToplist();
            next_window.Show();
            this.Close();
        }
    }
}