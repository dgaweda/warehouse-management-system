using System;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;

namespace DataAccess
{
    public class WMSDatabaseContext : DbContext
    {
        public WMSDatabaseContext(DbContextOptions<WMSDatabaseContext> options) : base(options)
        {

        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Seniority> Seniorities { get; set; }
        public DbSet<Pallet> Pallets { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Departure> Departures { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Product> Products { get; set; }
        
        public DbSet<OrderRow> OrderRows { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PalletRow> PalletRows { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = new Guid(),
                    Rank = 1,
                    Name = "collector",
                    Description = "Collecting orders",
                    Salary = 3000
                }
            );
        }
    }
}