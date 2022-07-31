using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities.EntityBase;
using DataAccess.Seeders.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Seeders
{
    public class DbInitializer
    {
        public static void Seed(WMSDatabaseContext context)
        {
            context.Database.Migrate();
            
            AddEntity(DummyDeliveries.GetDummyDeliveries(), context);
            AddEntity(DummyOrder.GetDummyOrders(), context);
            AddEntity(DummyDeparture.GetDummyDepartures(), context);
            AddEntity(DummyInvoice.GetDummyInvoices(), context);
            AddEntity(DummyLocation.GetDummyLocations(), context);
            AddEntity(DummyPallet.GetDummyPallets(), context);
            AddEntity(DummyProduct.GetDummyProducts(), context);
            AddEntity(DummyRoles.GetDummyRoles(), context);
            AddEntity(DummySeniority.GetDummySeniority(), context);
            AddEntity(DummyOrderRow.GetDummyOrderRows(), context);
            AddEntity(DummyPalletRow.GetDummyPalletRows(), context);
            AddEntity(DummyUser.GetDummyUsers(), context);
            context.SaveChanges();
        }

        private static void AddEntity<T>(List<T> entities, WMSDatabaseContext context) where T : EntityBase
        {
            var entity = context.Set<T>();
            if (!entity.Any())
            {
                context.AddRangeAsync(entities);
            }
        }
    }
}