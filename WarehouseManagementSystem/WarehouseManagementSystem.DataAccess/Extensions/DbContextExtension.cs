using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities.EntityBase;

namespace DataAccess.Extensions
{
    public static class DbContextExtension
    {
        public static WMSDatabaseContext AddEntities<T>(this WMSDatabaseContext context, List<T> entities) where T : EntityBase
        {
            var entity = context.Set<T>();
            if (!entity.Any())
            {
                context.AddRangeAsync(entities);
            }

            return context;
        }
        
        public static WMSDatabaseContext SetDummyInvoices(this WMSDatabaseContext context)
        {
            var invoice1 = context.Invoices.First();
            var invoice2 = context.Invoices.Skip(1).First();

            var delivery1 = context.Deliveries.First();
            var delivery2 = context.Deliveries.Skip(1).First();

            invoice1.DeliveryId = delivery1.Id;
            invoice2.DeliveryId = delivery2.Id;
            
            return context;
        }
        
        public static WMSDatabaseContext SetDummyLocations(this WMSDatabaseContext context)
        {
            var location1 = context.Locations.Skip(1).First();
            var location2 = context.Locations.Skip(2).First();

            var product1 = context.Products.First();
            var product2 = context.Products.Skip(1).First();

            location1.ProductId = product1.Id;
            location2.ProductId = product2.Id;
            
            return context;
        }
        
        public static WMSDatabaseContext SetDummyOrderRows(this WMSDatabaseContext context)
        {
            var product1 = context.Products.First();
            var product2 = context.Products.Skip(1).First();
            var product3 = context.Products.Skip(2).First();
            var product4 = context.Products.Skip(3).First();
            var product5 = context.Products.Skip(4).First();

            var order1 = context.Orders.Skip(2).First();
            var order2 = context.Orders.Skip(3).First();
            var order3 = context.Orders.Skip(4).First();

            var orderRow1 = context.OrderRows.First();
            var orderRow2 = context.OrderRows.Skip(1).First();
            var orderRow3 = context.OrderRows.Skip(2).First();
            var orderRow4 = context.OrderRows.Skip(3).First();
            var orderRow5 = context.OrderRows.Skip(4).First();
            var orderRow6 = context.OrderRows.Skip(5).First();
            var orderRow7 = context.OrderRows.Skip(6).First();

            orderRow1.ProductId = product1.Id;
            orderRow1.OrderId = order1.Id;

            orderRow2.ProductId = product2.Id;
            orderRow2.OrderId = order1.Id;

            orderRow3.ProductId = product2.Id;
            orderRow3.OrderId = order2.Id;
            
            orderRow4.ProductId = product3.Id;
            orderRow4.OrderId = order2.Id;
            
            orderRow5.ProductId = product4.Id;
            orderRow5.OrderId = order3.Id;
            
            orderRow6.ProductId = product5.Id;
            orderRow6.OrderId = order3.Id;
            
            orderRow7.ProductId = product1.Id;
            orderRow7.OrderId = order3.Id;
            
            return context;
        }
        
        public static WMSDatabaseContext SetDummyPallets(this WMSDatabaseContext context)
        {
            var pallet1 = context.Pallets.First();
            var pallet2 = context.Pallets.Skip(1).First();

            var order = context.Orders.First();

            var user = context.Users.First();

            var invoice = context.Invoices.First();

            var departure = context.Departures.First();

            pallet1.UserId = user.Id;
            pallet1.InvoiceId = invoice.Id;

            pallet2.DepartureId = departure.Id;
            pallet2.OrderId = order.Id;
            
            return context;
        }
        
        public static WMSDatabaseContext SetDummyPalletRows(this WMSDatabaseContext context)
        {
            var product1 = context.Products.First();
            var product2 = context.Products.Skip(1).First();

            var pallet1 = context.Pallets.First();
            var pallet2 = context.Pallets.Skip(1).First();

            var palletRow1 = context.PalletRows.First();
            var palletRow2 = context.PalletRows.Skip(1).First();
            var palletRow3 = context.PalletRows.Skip(2).First();
            var palletRow4 = context.PalletRows.Skip(3).First();

            palletRow1.ProductId = product1.Id;
            palletRow1.PalletId = pallet1.Id;
            
            palletRow2.ProductId = product2.Id;
            palletRow2.PalletId = pallet1.Id;
            
            palletRow3.ProductId = product1.Id;
            palletRow3.PalletId = pallet2.Id;
            
            palletRow4.ProductId = product2.Id;
            palletRow4.PalletId = pallet2.Id;
            
            return context;
        }
        
        public static WMSDatabaseContext SetDummySeniority(this WMSDatabaseContext context)
        {
            var seniority1 = context.Seniorities.First();
            var seniority2 = context.Seniorities.Skip(1).First();
            var seniority3 = context.Seniorities.Skip(2).First();

            var user1 = context.Users.First();
            var user2 = context.Users.Skip(1).First();
            var user3 = context.Users.Skip(2).First();

            seniority1.UserId = user1.Id;
            seniority2.UserId = user2.Id;
            seniority3.UserId = user3.Id;
            
            return context;
        }
        
        public static WMSDatabaseContext SetDummyUsers(this WMSDatabaseContext context)
        {
            var user1 = context.Users.First();
            var user2 = context.Users.Skip(1).First();
            var user3 = context.Users.Skip(2).First();

            var role1 = context.Roles.First();
            var role2 = context.Roles.Skip(1).First();
            var role3 = context.Roles.Skip(3).First();

            user1.RoleId = role1.Id;
            user2.RoleId = role2.Id;
            user3.RoleId = role3.Id;

            return context;
        }

        public static bool EntitesHasData(this WMSDatabaseContext context)
        {
            return context.Deliveries.Any() &&
                   context.Departures.Any() &&
                   context.Invoices.Any() &&
                   context.Locations.Any() &&
                   context.Orders.Any() &&
                   context.Pallets.Any() &&
                   context.Products.Any() &&
                   context.Roles.Any() &&
                   context.Seniorities.Any() &&
                   context.Users.Any() &&
                   context.OrderRows.Any() &&
                   context.PalletRows.Any();
        }
    }
}