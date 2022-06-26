using AutoMapper;
using DataAccess.Entities;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {

            CreateMap<Product, ProductDto>();

            CreateMap<AddProductRequest, Product>();

            CreateMap<EditProductRequest, Product>();

            CreateMap<RemoveProductRequest, Product>();

        }
    }
}
