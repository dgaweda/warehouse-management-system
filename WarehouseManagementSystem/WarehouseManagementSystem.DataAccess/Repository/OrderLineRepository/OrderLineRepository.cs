﻿using DataAccess.Entities;
using DataAccess.Repository.OrderRepository;

namespace DataAccess.Repository.OrderLineRepository
{
    public class OrderLineRepository : Repository<OrderLine>, IOrderLineRepository
    {
        public OrderLineRepository(WMSDatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}