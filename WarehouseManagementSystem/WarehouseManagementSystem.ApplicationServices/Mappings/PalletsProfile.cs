using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class PalletsProfile : Profile
    {
        public PalletsProfile()
        {
            CreateMap<Pallet, API.Domain.Models.Pallet>()
                .ForMember(x => x.Barcode, y => y.MapFrom(z => z.Barcode))
                .ForMember(x => x.Order, y => y.MapFrom(z => z.Order))
                .ForMember(x => x.Departure, y => y.MapFrom(z => z.Departure))
                .ForMember(x => x.Delivery, y => y.MapFrom(z => z.Invoice.Delivery))
                .ForMember(x => x.Employee, y => y.MapFrom(z => z.Employee));
        }
    }
}
