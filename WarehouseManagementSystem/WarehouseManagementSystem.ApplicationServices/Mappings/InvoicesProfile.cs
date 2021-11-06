using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class InvoicesProfile : Profile
    {
        public InvoicesProfile()
        {
            CreateMap<Invoice, API.Domain.Models.Invoice>()
                .ForMember(dest => dest.InvoiceNumber, opt => opt.MapFrom(src => src.InvoiceNumber))
                .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => src.Provider))
                .ForMember(dest => dest.InvoiceReceiptDate, opt => opt.MapFrom(src => src.InvoiceReceiptDate))
                .ForMember(dest => dest.InvoiceDate, opt => opt.MapFrom(src => src.InvoiceDate))
                .ForMember(dest => dest.DeliveryName, opt => opt.MapFrom(src => src.Delivery.Name));

            CreateMap<AddInvoiceRequest, Invoice>()
                .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => src.Provider))
                .ForMember(dest => dest.InvoiceDate, opt => opt.MapFrom(src => src.InvoiceDate))
                .ForMember(dest => dest.InvoiceReceiptDate, opt => opt.MapFrom(src => src.InvoiceReceiptDate))
                .ForMember(dest => dest.DeliveryId, opt => opt.MapFrom(src => src.DeliveryId));

        }
    }
}
