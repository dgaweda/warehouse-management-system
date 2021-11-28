using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class PalletLinesProfile : Profile
    {
        public PalletLinesProfile()
        {
            CreateMap<PalletLine, API.Domain.Models.PalletLine>()
                .ForMember(dest => dest.PalletBarcode, opt => opt.MapFrom(src => src.Pallet.Barcode))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ProductAmount, opt => opt.MapFrom(src => src.ProductAmount))
                .ForMember(dest => dest.OrderBarcode, opt => opt.MapFrom(src => src.Pallet.Order != null ? src.Pallet.Order.Barcode : "NO_ORDER"))
                .ForMember(dest => dest.DepartureName, opt => opt.MapFrom(src => src.Pallet.Departure != null ? src.Pallet.Departure.Name : "NO_DEPARTURE"))
                .ForMember(dest => dest.InvoiceNumber, opt => opt.MapFrom(src => src.Pallet.Invoice != null ? src.Pallet.Invoice.InvoiceNumber : "NO_INVOICE"))
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Pallet.Employee != null ? src.Pallet.Employee.Name : "NO_EMPLOYEE"))
                .ForMember(dest => dest.EmployeeLastName, opt => opt.MapFrom(src => src.Pallet.Employee != null ? src.Pallet.Employee.LastName : "NO_EMPLOYEE"));


            CreateMap<SetProductAmountRequest, PalletLine>()
                .ForMember(dest => dest.PalletId, opt => opt.MapFrom(src => src.PalletId))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.ProductAmount, opt => opt.MapFrom(src => src.ProductAmount));
        }
    }
}
