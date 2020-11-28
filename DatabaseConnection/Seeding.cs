﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConnection
{
    class Seeding
    {
        static void Main()
        {
            using (var ctx = new Context())
            {
                ctx.RemoveRange(ctx.Sales);
                ctx.RemoveRange(ctx.Movies);
                ctx.RemoveRange(ctx.Customers);
                
                ctx.AddRange(new List<Customer> {
                    new Customer { FirstName = "Björn", LastName = "Strömberg", Email = "bjorn@email.com", Password = "user1", Username = "Bjarne" },
                    new Customer { FirstName = "Robert", LastName = "Sörensen", Email = "robert@email.com", Password = "user2", Username = "Rhabby"  },
                    new Customer { FirstName = "Lujain", LastName = "Al-shammari", Email = "lujain@email.com", Password = "user3", Username = "Lujain123"  },
                });
                
                // Här laddas data in från SeedData foldern för att fylla ut Movies tabellen
                var movies = new List<Movie>();
                var lines = File.ReadAllLines(@"..\..\..\SeedData\MovieGenre.csv");
                for (int i = 1; i < 200; i++)
                {
                    // imdbId,Imdb Link,Title,IMDB Score,Genre,Poster
                    var cells = lines[i].Split(',');

                    var url = cells[5].Trim('"');

                    // Hoppa över alla icke-fungerande url:er
                    try { var test = new Uri(url); }
                    catch (Exception) { continue; }

                    movies.Add(new Movie { Title = cells[2], ImageURL = url });
                }
                ctx.AddRange(movies);

                ctx.SaveChanges();
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(ctx.Customers);
                }
            }
        }
    }
}