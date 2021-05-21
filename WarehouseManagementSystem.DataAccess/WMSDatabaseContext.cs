using Microsoft.EntityFrameworkCore;
using WarehouseManagemnetSystem.DataAccess.Entities;

namespace WarehouseManagementSystem.DataAccess
{
    public class WMSDatabaseContext : DbContext
    {
        public WMSDatabaseContext(DbContextOptions<WMSDatabaseContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set;  }
    }
}