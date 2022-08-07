using System;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.OrderRepository;

namespace DataAccess.CQRS.Query.OrderQueries
{
    public class GetOrderByIdQuery: QueryBase<Order>
    {
        public Guid Id { get; set; }
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdQuery(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public override async Task<Order> Execute()
        {
            return await _orderRepository.GetByIdAsync(Id);
        }
    }
}