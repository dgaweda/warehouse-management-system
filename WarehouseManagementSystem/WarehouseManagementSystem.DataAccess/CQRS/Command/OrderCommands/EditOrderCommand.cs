using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Repository.OrderRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.OrderCommands
{
    public class EditOrderCommand: CommandBase<Order, IOrderRepository>
    {
        public override async Task Execute(IOrderRepository orderRepository)
        {
            await orderRepository.UpdateAsync(Parameter);
        }
    }
}