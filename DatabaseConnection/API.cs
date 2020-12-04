using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace DatabaseConnection
{
    public class API
    {
        
        public static Context ctx = new Context();

       
        

        public static List<Movie> GetMovieSlice(int skip_x, int take_x)
        {
            return ctx.Movies
                .OrderBy(m => m.Title)
                .Skip(skip_x)
                .Take(take_x)
                .ToList();
        }
        public static List<Movie> GetMovieSliceTop(int skip_x, int take_x)
        {
            return ctx.Movies
                .OrderBy(r => r.Rating)
                .Skip(skip_x)
                .Take(take_x)
                .ToList();
        }
        
        public static List<Rental> GetRentalSlice(int user)
        {
            return ctx.Sales
                .OrderBy(s => s.Date.Date)
                .Where(c => c.Customer.Id == user)
                .ToList();
        }
        public static List<Movie> GetMoviebyCategory (string genre)
        {
            return ctx.Movies
                .OrderByDescending(m => m.Title)
                .Where(g => g.Genre == genre)
                .ToList();
        }

        public static Customer GetCustomerByName(string name)
        {
                return ctx.Customers
                .FirstOrDefault(c => c.Username.ToLower() == name.ToLower());
                   
        }
        public static Customer GetCustomerByPassword(string password)
        {
            return ctx.Customers
                .FirstOrDefault(c => c.Username.ToLower() == password.ToLower());
        }
        public static bool RegisterSale(Customer customer, Movie movie)
        {
            // Försök att lägga till ett nytt sales record
            try
            {
                ctx.Add(new Rental() { Date = DateTime.Now, Customer = customer, Movie = movie });

                bool one_record_added = ctx.SaveChanges() == 1;
                return one_record_added;
            }
            catch (DbUpdateException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.InnerException.Message);
                return false;
            }
        }
        
        
    }
}