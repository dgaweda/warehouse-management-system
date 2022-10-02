using AutoMapper;
using DataAccess.Entities;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class PalletLinesProfile : Profile
    {
        public PalletLinesProfile()
        {
            CreateMap<PalletRow, ProductPalletLineDto>()
                .ForMember(dest => dest.PalletBarcode, opt => opt.MapFrom(src => src.Pallet.Barcode))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ProductAmount, opt => opt.MapFrom(src => src.ProductAmount))
                .ForMember(dest => dest.OrderBarcode, opt => opt.MapFrom(src => src.Pallet.Order != null ? src.Pallet.Order.Barcode : string.Empty))
                .ForMember(dest => dest.DepartureName, opt => opt.MapFrom(src => src.Pallet.Departure != null ? src.Pallet.Departure.Name : string.Empty))
                .ForMember(dest => dest.InvoiceNumber, opt => opt.MapFrom(src => src.Pallet.Invoice != null ? src.Pallet.Invoice.InvoiceNumber : string.Empty))
                .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.Pallet.User != null ? src.Pallet.User.Name : string.Empty))
                .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.Pallet.User != null ? src.Pallet.User.Lastname : string.Empty));


            CreateMap<DecreaseProductAmountRequest, PalletRow>()
                .ForMember(dest => dest.PalletId, opt => opt.MapFrom(src => src.PalletId))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.ProductAmount, opt => opt.MapFrom(src => src.ProductAmount));
        }
    }
}
