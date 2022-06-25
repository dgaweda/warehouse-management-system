using System;
using AutoMapper;
using DataAccess.Entities;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Order, API.Domain.Models.Order>()
                .ForMember(x => x.OrderState, y => y.MapFrom(z => Enum.GetName(z.OrderState)))
                .ForMember(x => x.Barcode, y => y.MapFrom(z => z.Barcode))
                .ForMember(x => x.PickingStart, y => y.MapFrom(z => z.PickingStart))
                .ForMember(x => x.PickingEnd, y => y.MapFrom(z => z.PickingEnd))
                .ForMember(x => x.OrderLines, y => y.MapFrom(z => z.OrderLines))
                .ForMember(x => x.LinesCount, y => y.MapFrom(z => z.OrderLines.Count));

            CreateMap<AddOrderRequest, Order>()
                .ForMember(x => x.Barcode, y => y.MapFrom(z => z.Barcode))
                .ForMember(x => x.OrderLines, y => y.MapFrom(z => z.OrderLines));

            CreateMap<EditOrderRequest, Order>()
                .ForMember(x => x.Barcode, y => y.MapFrom(z => z.Barcode))
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.OrderState, y => y.MapFrom(z => z.OrderState));

            CreateMap<RemoveOrderRequest, Order>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));
        }
    }
}
