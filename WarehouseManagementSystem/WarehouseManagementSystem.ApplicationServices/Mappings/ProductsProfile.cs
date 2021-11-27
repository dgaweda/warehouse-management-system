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
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {

            CreateMap<Product, API.Domain.Models.Product>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.ExpirationDate, y => y.MapFrom(z => z.ExpirationDate))
                .ForMember(x => x.Barcode, y => y.MapFrom(z => z.Barcode))
                .ForMember(x => x.PalletLines, y => y.MapFrom(src => src.PalletLines));

            CreateMap<AddProductRequest, Product>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.ExpirationDate, y => y.MapFrom(z => z.ExpirationDate))
                .ForMember(x => x.Barcode, y => y.MapFrom(z => z.Barcode));

            CreateMap<EditProductRequest, Product>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.ExpirationDate, y => y.MapFrom(z => z.ExpirationDate))
                .ForMember(x => x.Barcode, y => y.MapFrom(z => z.Barcode));

            CreateMap<RemoveProductRequest, Product>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

        }
    }
}
