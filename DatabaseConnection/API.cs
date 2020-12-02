using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sitecore.FakeDb;

namespace DatabaseConnection
{
    public static class API
    {
        // Här har jag ett kontext tillgängligt för alla API metoder.
        static Context ctx;

        // Statiska konstruktorer kallas på innan den statiska klassen används.
        static API()
        {
            ctx = new Context();
        }

        public static List<Movie> GetMovieSlice(int skip_x, int take_x)
        {
            return ctx.Movies
                .OrderBy(m => m.Title)
                .Skip(skip_x)
                .Take(take_x)
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