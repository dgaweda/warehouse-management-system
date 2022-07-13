using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Repository.OrderRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.OrderCommands
{
    public class RemoveOrderCommand: CommandBase<Order, Unit, IOrderRepository>
    {
        public override async Task<Unit> Execute(IOrderRepository orderRepository)
        {
            return await orderRepository.DeleteAsync(Parameter.Id);
        }
    }
}