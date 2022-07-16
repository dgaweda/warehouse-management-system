using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.OrderRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Query.Queries.OrderQueries
{
    public class GetOrdersQuery: QueryBase<List<Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersQuery(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public override async Task<List<Order>> Execute()
        {
            return await _orderRepository.GetAll().ToListAsync();
        }
    }
}