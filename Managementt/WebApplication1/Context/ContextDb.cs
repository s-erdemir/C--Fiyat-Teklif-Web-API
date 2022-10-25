using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1.Entities;

namespace WebApplication1.Context
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {
        }

        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Explanation> Explanations { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Prepared> Prepareds { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<TotalPrice> TotalPrices { get; set; }
    }
}
