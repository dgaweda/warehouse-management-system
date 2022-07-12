using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.CQRS.Query.Queries;
using DataAccess.Extensions;
using DataAccess.Repository.ProductRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Queries.DeliveryProductQueries
{
    public class GetProductsQuery : QueryBase<List<Product>, IProductRepository>
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Barcode { get; set; }

        public override async Task<List<Product>> Execute(IProductRepository productRepository)
        {
            var products = await productRepository.GetAllAsync();
            
            return products
                .FilterByName(Name)
                .FilterByBarcode(Barcode)
                .FilterById(Id);
        }
    }
}
