using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Entities.EntityBase;
using DataAccess.Extensions;
using DataAccess.Seeders.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Seeders
{
    public class DbInitializer
    {
        public static void Seed(WMSDatabaseContext context)
        {
            if (context.Database.EnsureCreated())
            {
                context.Database.Migrate();
            }
            
            if (context.EntitesHasData())
                return;
            
            context
                .AddEntities(DummyDeliveries.GetDummyDeliveries())
                .AddEntities(DummyOrder.GetDummyOrders())
                .AddEntities(DummyDeparture.GetDummyDepartures())
                .AddEntities(DummyInvoice.GetDummyInvoices())
                .AddEntities(DummyLocation.GetDummyLocations())
                .AddEntities(DummyPallet.GetDummyPallets())
                .AddEntities(DummyProduct.GetDummyProducts())
                .AddEntities(DummyRoles.GetDummyRoles())
                .AddEntities(DummySeniority.GetDummySeniority())
                .AddEntities(DummyOrderRow.GetDummyOrderRows())
                .AddEntities(DummyPalletRow.GetDummyPalletRows())
                .AddEntities(DummyUser.GetDummyUsers())
                .SaveChanges();
            
            context
                .SetDummyInvoices()
                .SetDummyLocations()
                .SetDummyPallets()
                .SetDummySeniority()
                .SetDummyOrderRows()
                .SetDummyPalletRows()
                .SetDummyUsers()
                .SaveChanges();
        }
    }
}