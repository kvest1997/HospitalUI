using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DAL.Context
{
    public class TestDB : DbContext
    {
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Deal> Deals { get; set; }

        public TestDB(DbContextOptions options) : base(options) { }
    }
}
