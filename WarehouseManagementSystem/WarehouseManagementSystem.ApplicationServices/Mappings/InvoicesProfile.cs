using AutoMapper;
using DataAccess.Entities;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class InvoicesProfile : Profile
    {
        public InvoicesProfile()
        {
            CreateMap<Invoice, InvoiceDto>()
                .ForMember(dest => dest.InvoiceNumber, opt => opt.MapFrom(src => src.InvoiceNumber))
                .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => src.Provider))
                .ForMember(dest => dest.InvoiceReceiptDate, opt => opt.MapFrom(src => src.ReceiptDateTime))
                .ForMember(dest => dest.InvoiceDate, opt => opt.MapFrom(src => src.CreationDate))
                .ForMember(dest => dest.DeliveryName, opt => opt.MapFrom(src => src.Delivery.Name));

            CreateMap<AddInvoiceRequest, Invoice>()
                .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => src.Provider))
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate))
                .ForMember(dest => dest.ReceiptDateTime, opt => opt.MapFrom(src => src.ReceiptDateTime))
                .ForMember(dest => dest.DeliveryId, opt => opt.MapFrom(src => src.DeliveryId));

            CreateMap<RemoveInvoiceRequest, Invoice>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.InvoiceId));

            CreateMap<EditInvoiceRequest, Invoice>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => src.Provider))
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate))
                .ForMember(dest => dest.ReceiptDateTime, opt => opt.MapFrom(src => src.ReceiptDateTime))
                .ForMember(dest => dest.DeliveryId, opt => opt.MapFrom(src => src.DeliveryId));
        }
    }
}
