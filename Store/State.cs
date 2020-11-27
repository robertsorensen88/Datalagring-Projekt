using System;
using System.Collections.Generic;
using System.Text;
using DatabaseConnection;
using Microsoft.EntityFrameworkCore;

namespace Store
{
    class State
    {

        public static Context ct = new Context();
        public static Customer User { get; set; }
        public static List<Movie> Movies { get; set; }
        public static Movie Pick { get; set; }

        public static Rental Rental { get; set; }
    }
}
