﻿
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Repository.OrderRepository;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.CQRS.Commands.OrderCommands
{
    public class AddOrderCommand: CommandBase<Order, Order, IOrderRepository>
    {
        public override async Task<Order> Execute(IOrderRepository orderRepository)
        {
            Parameter.OrderState = OrderState.RECEIVED;
            Parameter.OrderLines.ForEach(x => x.OrderId = Parameter.Id);
            await orderRepository.GetDbContext().Set<OrderLine>().AddRangeAsync(Parameter.OrderLines);
            await orderRepository.AddAsync(Parameter);
            await orderRepository.GetDbContext().SaveChangesAsync();
        }
    }
}