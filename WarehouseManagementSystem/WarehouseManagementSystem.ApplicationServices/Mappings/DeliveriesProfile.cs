using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class DeliveriesProfile : Profile
    {
        public DeliveriesProfile()
        {
            CreateMap<Delivery, API.Domain.Models.Delivery>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.ArrivalTime, y => y.MapFrom(z => z.Arrival));
        }
    }
}
