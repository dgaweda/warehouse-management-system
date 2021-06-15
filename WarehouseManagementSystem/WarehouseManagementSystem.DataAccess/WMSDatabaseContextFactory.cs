using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccess
{
    public class WMSDatabaseContextFactory : IDesignTimeDbContextFactory<WMSDatabaseContext>
    {
        public WMSDatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WMSDatabaseContext>();
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=WarehouseManagementSystemStorage;Integrated Security=True");
            return new WMSDatabaseContext(optionsBuilder.Options);
        }
    }
}