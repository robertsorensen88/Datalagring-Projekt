﻿using System;
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


            int movie_skip_count = 0;
            int movie_take_count = 30;
            State.Movies = API.GetMovieSlice(movie_skip_count, movie_take_count);

            int column_count = MovieGrid.ColumnDefinitions.Count;

            /*
             * cols = 3, movs = 10
             * 
             * rows = movs/cols = 3.333
             * 
             * vi behöver alltså 4 rader. Vi kan inte bara göra en vanlig heltalsdivision.
             * 
             * rows = ceiling(movs/cols) = 4
             */
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
                    if (i < State.Movies.Count)
                    {
                        // Hämta ett film record
                        var movie = State.Movies[i];

                        // Försök att skapa en Image Controller(legobit) och
                        // placera den i rätt Grid cell enl. x,y koordinaterna
                        // Skapa en Image som visar filmomslaget
                        try
                        {
                            

                            var title = new Label() { };
                            title.Content = movie.Title;
                            title.HorizontalAlignment = HorizontalAlignment.Center;
                            title.VerticalAlignment = VerticalAlignment.Top;
                            title.Foreground = name.Foreground;
                            title.FontSize = 12;
                            title.Margin = new Thickness(2, 2, 2, 2);

                            var image = new Image() { };
                            image.Cursor = Cursors.Hand; // Visa en 'click me' hand när man hovrar över bilden
                            image.HorizontalAlignment = HorizontalAlignment.Center;
                            image.VerticalAlignment = VerticalAlignment.Center;
                            image.Margin = new Thickness(2, 2, 2, 2);
                            image.Width = 60;
                            image.Height = 60;
                            image.Stretch = Stretch.Fill;
                            image.Source = new BitmapImage(new Uri(movie.ImageURL));

                            var genre = new Label() { };
                            genre.Content = movie.Genre;
                            genre.HorizontalAlignment = HorizontalAlignment.Center;
                            genre.VerticalAlignment = VerticalAlignment.Bottom;
                            genre.Foreground = name.Foreground;
                            genre.FontSize = 12;
                            genre.Margin = new Thickness(2, 2, 2, 2);


                            image.MouseUp += Image_MouseUp;

                            // Placera in Image i Grid
                            MovieGrid.Children.Add(title); // säger till att texten ska tillhöra den gridden
                            Grid.SetRow(title, y); // vilken grid i y
                            Grid.SetColumn(title, x); // vilken grid i x
                            MovieGrid.Children.Add(image);
                            Grid.SetRow(image, y);
                            Grid.SetColumn(image, x);
                            MovieGrid.Children.Add(genre);
                            Grid.SetRow(genre, y);
                            Grid.SetColumn(genre, x);
                        }

                        // Hämta hem bildlänken till RAM

                        catch (Exception e) when (e is ArgumentNullException || e is System.IO.FileNotFoundException || e is UriFormatException) 
                        {
                            continue;
                        }
                        
                    }
                        // Lägg till Image i Grid
                        
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

        private void ToplistClick(object sender, RoutedEventArgs e)
        {
            var next_window = new MainWindowToplist();
            next_window.Show();
            this.Close();
        
        }

        private void MyAccClick(object sender, RoutedEventArgs e)
        {
            var next_window = new MyAccountWindow();
            next_window.Show();
            this.Close();
        }

        private void LogoutClick(object sender, RoutedEventArgs e)
        {
            var next_window = new LoginWindow();
            next_window.Show();
            this.Close();
        }

        private void GenreClick(object sender, RoutedEventArgs e)
        {
            var next_window = new GenreWindow();
            next_window.Show();
            this.Close();
        }
    }
}
