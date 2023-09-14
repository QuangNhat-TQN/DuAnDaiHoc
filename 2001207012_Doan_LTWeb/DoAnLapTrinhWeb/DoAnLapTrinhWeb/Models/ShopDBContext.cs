using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DoAnLapTrinhWeb.Models
{
    public class ShopDBContext : DbContext
    {
        public ShopDBContext() : base("MyConnectionString") { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}