using AutoMapper;
using DataAccess.Entities;
using System.Linq;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class PalletsProfile : Profile
    {
        public PalletsProfile()
        {
            CreateMap<Pallet, PalletDto>()
                .ForMember(x => x.PalletStatus, y => y.MapFrom(z => z.PalletStatus))
                .ForMember(x => x.Barcode, y => y.MapFrom(z => z.Barcode))
                .ForMember(x => x.OrderBarcode, y => y.MapFrom(z => z.Order != null ? z.Order.Barcode : string.Empty))
                .ForMember(x => x.DepartureName, y => y.MapFrom(z => z.Departure != null ? z.Departure.Name : string.Empty))
                .ForMember(x => x.DeliveryName, y => y.MapFrom(z => z.Invoice != null ? z.Invoice.Delivery.Name : string.Empty))
                .ForMember(x => x.UserFirstName, y => y.MapFrom(src => src.User != null ? src.User.Name : string.Empty))
                .ForMember(x => x.UserLastName, y => y.MapFrom(src => src.User != null ? src.User.LastName : string.Empty))
                .ForMember(x => x.Products, y => y.MapFrom(z => z.PalletsProducts.Select(x => new { x.Product.Name, x.Product.ExpirationDate, x.Product.Barcode, x.ProductAmount })));
                

            CreateMap<RemovePalletRequest, Pallet>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PalletId));

            CreateMap<AddPalletRequest, Pallet>()
                .ForMember(x => x.Barcode, y => y.MapFrom(z => z.Barcode))
                .ForMember(x => x.OrderId, y => y.MapFrom(z => z.OrderId))
                .ForMember(x => x.DepartureId, y => y.MapFrom(z => z.DepartureId))
                .ForMember(x => x.InvoiceId, y => y.MapFrom(z => z.InvoiceId))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId));

            CreateMap<SetPalletDestinationRequest, Pallet>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.OrderId, y => y.MapFrom(z => z.OrderId))
                .ForMember(x => x.DepartureId, y => y.MapFrom(z => z.DepartureId))
                .ForMember(x => x.InvoiceId, y => y.MapFrom(z => z.InvoiceId))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId));
        }
    }
}
