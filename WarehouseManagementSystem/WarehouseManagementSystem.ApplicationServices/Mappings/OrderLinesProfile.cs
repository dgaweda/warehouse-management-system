using AutoMapper;
using DataAccess.Entities;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class OrderLinesProfile : Profile
    {
        public OrderLinesProfile()
        {
            CreateMap<OrderLine, API.Domain.Models.OrderLine>()
                .ForMember(x => x.ProductId, y => y.MapFrom(z => z.ProductId))
                .ForMember(x => x.OrderId, y => y.MapFrom(z => z.OrderId))
                .ForMember(x => x.Order, y => y.MapFrom(z => z.Order))
                .ForMember(x => x.Product, y => y.MapFrom(z => z.Product))
                .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price));
        }
    }
}