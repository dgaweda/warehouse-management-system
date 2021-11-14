using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;

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

            CreateMap<RemovePalletRequest, Pallet>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PalletId));

            CreateMap<AddPalletRequest, Pallet>()
                .ForMember(x => x.Barcode, y => y.MapFrom(z => z.Barcode))
                .ForMember(x => x.OrderId, y => y.MapFrom(z => z.OrderId))
                .ForMember(x => x.DepartureId, y => y.MapFrom(z => z.DepartureId))
                .ForMember(x => x.InvoiceId, y => y.MapFrom(z => z.InvoiceId))
                .ForMember(x => x.EmployeeId, y => y.MapFrom(z => z.EmployeeId));

        }
    }
}
