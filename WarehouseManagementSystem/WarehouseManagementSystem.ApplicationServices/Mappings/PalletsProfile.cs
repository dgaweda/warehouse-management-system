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
                .ForMember(x => x.PalletStatus, y => y.MapFrom(z => z.PalletStatus))
                .ForMember(x => x.Barcode, y => y.MapFrom(z => z.Barcode))
                .ForMember(x => x.OrderBarcode, y => y.MapFrom(z => z.Order != null ? z.Order.Barcode : "NO_ORDER"))
                .ForMember(x => x.DepartureName, y => y.MapFrom(z => z.Departure != null ? z.Departure.Name : "NO_DEPARTURE"))
                .ForMember(x => x.DeliveryName, y => y.MapFrom(z => z.Invoice.Delivery != null ? z.Invoice.Delivery.Name : "NO_DELIVERY"))
                .ForMember(x => x.EmployeeName, y => y.MapFrom(src => src.Employee != null ? src.Employee.Name : "NO_EMPLOYEE"))
                .ForMember(x => x.EmployeeLastName, y => y.MapFrom(src => src.Employee != null ? src.Employee.LastName : "NO_EMPLOYEE"))
                .ForMember(x => x.Products, y => y.MapFrom(z => z.PalletsProducts.Select(x => new { x.Product.Name, x.Product.ExpirationDate, x.Product.Barcode, x.ProductAmount })));
                

            CreateMap<RemovePalletRequest, Pallet>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PalletId));

            CreateMap<AddPalletRequest, Pallet>()
                .ForMember(x => x.Barcode, y => y.MapFrom(z => z.Barcode))
                .ForMember(x => x.OrderId, y => y.MapFrom(z => z.OrderId))
                .ForMember(x => x.DepartureId, y => y.MapFrom(z => z.DepartureId))
                .ForMember(x => x.InvoiceId, y => y.MapFrom(z => z.InvoiceId))
                .ForMember(x => x.EmployeeId, y => y.MapFrom(z => z.EmployeeId));

            CreateMap<SetPalletDestinationRequest, Pallet>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.OrderId, y => y.MapFrom(z => z.OrderId))
                .ForMember(x => x.DepartureId, y => y.MapFrom(z => z.DepartureId))
                .ForMember(x => x.InvoiceId, y => y.MapFrom(z => z.InvoiceId))
                .ForMember(x => x.EmployeeId, y => y.MapFrom(z => z.EmployeeId));
        }
    }
}
