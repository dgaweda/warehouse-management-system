using AutoMapper;
using DataAccess.Entities;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.OrderLine;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class OrderLinesProfile : Profile
    {
        public OrderLinesProfile()
        {
            CreateMap<OrderLine, API.Domain.Models.OrderLine>()
                .ForMember(x => x.ProductId, y => y.MapFrom(z => z.ProductId))
                .ForMember(x => x.OrderId, y => y.MapFrom(z => z.OrderId))
                .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price));
            
            CreateMap<AddOrderLineRequest, OrderLine>()
                .ForMember(x => x.ProductId, y => y.MapFrom(z => z.ProductId))
                .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price));
        }
    }
}