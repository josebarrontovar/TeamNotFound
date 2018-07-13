using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebFinal.Models
{
    public class DataContext: DbContext
    {

        public DbSet<City> DataCity { get; set; }
        public DbSet<DataForm> DForm { get; set; }
    }
}