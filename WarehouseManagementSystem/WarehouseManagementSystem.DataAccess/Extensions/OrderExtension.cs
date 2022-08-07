using System;
using System.Linq;
using DataAccess.Entities;

namespace DataAccess.Extensions
{
    public static class OrderExtension
    {
        public static IQueryable<Order> FilterById(this IQueryable<Order> orders, Guid? id)
        {
            return id == null ? orders : orders.Where(x => x.Id == id);
        }
    }
}