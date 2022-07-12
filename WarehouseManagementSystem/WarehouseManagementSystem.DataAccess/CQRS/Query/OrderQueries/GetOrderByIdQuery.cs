using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.OrderRepository;

namespace DataAccess.CQRS.Query.Queries.OrderQueries
{
    public class GetOrderByIdQuery: QueryBase<Order, IOrderRepository>
    {
        public int Id { get; set; }
        public override async Task<Order> Execute(IOrderRepository orderRepository)
        {
            return await orderRepository.GetByIdAsync(Id);
        }
    }
}