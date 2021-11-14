using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Order, API.Domain.Models.Order>()
                .ForMember(x => x.State, y => y.MapFrom(z => z.OrderState))
                .ForMember(x => x.Barcode, y => y.MapFrom(z => z.Barcode))
                .ForMember(x => x.PickingStart, y => y.MapFrom(z => z.PickingStart))
                .ForMember(x => x.PickingEnd, y => y.MapFrom(z => z.PickingEnd));
        }
    }
}
