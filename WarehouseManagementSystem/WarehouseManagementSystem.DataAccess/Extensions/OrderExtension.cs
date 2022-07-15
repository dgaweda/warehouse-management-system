using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;

namespace DataAccess.Extensions
{
    public static class OrderExtension
    {
        public static List<Order> FilterById(this List<Order> orders, Guid? id)
        {
            return id == null ? orders : orders.Where(x => x.Id == id).ToList();
        }
    }
}