using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;

namespace DataAccess
{
    public class WMSDatabaseContext : DbContext
    {
        public WMSDatabaseContext(DbContextOptions<WMSDatabaseContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set;  }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Seniority> Seniorities { get; set; }
        public DbSet<Pallet> Pallets { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Departure> Departures { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductPalletLine> ProductPalletLines { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}