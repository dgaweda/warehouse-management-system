using AutoMapper;
using DataAccess.Entities;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.OrderLine;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class OrderLinesProfile : Profile
    {
        public OrderLinesProfile()
        {
            CreateMap<OrderRow, OrderLineDto>();

            CreateMap<AddOrderLineRequest, OrderRow>();
        }
    }
}