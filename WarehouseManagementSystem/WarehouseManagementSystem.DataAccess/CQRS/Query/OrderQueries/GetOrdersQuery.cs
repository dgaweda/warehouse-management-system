﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.OrderRepository;

namespace DataAccess.CQRS.Query.Queries.OrderQueries
{
    public class GetOrdersQuery: QueryBase<List<Order>, IOrderRepository>
    {
        public override async Task<List<Order>> Execute(IOrderRepository orderRepository)
        {
            return await orderRepository.GetAllAsync();
        }
    }
}