using System.Linq;
using AutoMapper;
using DataAccess.Entities;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Order, API.Domain.Models.Order>()
                .ForMember(x => x.OrderState, y => y.MapFrom(z => z.OrderState))
                .ForMember(x => x.Barcode, y => y.MapFrom(z => z.Barcode))
                .ForMember(x => x.PickingStart, y => y.MapFrom(z => z.PickingStart))
                .ForMember(x => x.PickingEnd, y => y.MapFrom(z => z.PickingEnd))
                .ForMember(x => x.LinesCount, y => y.MapFrom(z => z.OrderLines.Count));
        }
    }
}
