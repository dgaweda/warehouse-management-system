using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;

namespace DataAccess.CQRS.Extensions
{
    public static class OrderExtension
    {
        public static List<Order> FilterById(this List<Order> orders, int? id)
        {
            return id == null ? orders : orders.Where(x => x.Id == id).ToList();
        }
    }
}