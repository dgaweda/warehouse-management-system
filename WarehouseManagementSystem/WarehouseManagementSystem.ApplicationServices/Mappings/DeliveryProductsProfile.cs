using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.DeliveryProduct;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class DeliveryProductsProfile : Profile
    {
        public DeliveryProductsProfile()
        {

            CreateMap<DeliveryProduct, API.Domain.Models.DeliveryProduct>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount))
                .ForMember(x => x.ExpirationDate, y => y.MapFrom(z => z.ExpirationDate))
                .ForMember(x => x.Barcode, y => y.MapFrom(z => z.Barcode))
                .ForMember(x => x.Pallet, y => y.MapFrom(src => src.DeliveryProductPalletLines));

            CreateMap<AddDeliveryProductRequest, DeliveryProduct>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount))
                .ForMember(x => x.ExpirationDate, y => y.MapFrom(z => z.ExpirationDate))
                .ForMember(x => x.Barcode, y => y.MapFrom(z => z.Barcode));

            CreateMap<EditDeliveryProductRequest, DeliveryProduct>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.ExpirationDate, y => y.MapFrom(z => z.ExpirationDate))
                .ForMember(x => x.Barcode, y => y.MapFrom(z => z.Barcode));

            CreateMap<EditDeliveryProductAmountRequest, DeliveryProduct>()
                .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount));
        }
    }
}
