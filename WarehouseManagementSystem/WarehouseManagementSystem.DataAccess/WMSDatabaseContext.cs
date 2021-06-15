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

    }
}