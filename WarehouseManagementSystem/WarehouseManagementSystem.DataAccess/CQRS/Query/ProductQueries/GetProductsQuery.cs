using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Repository.ProductRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Query.ProductQueries
{
    public class GetProductsQuery : QueryBase<List<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQuery(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public string Name { get; set; }
        public Guid Id { get; set; }
        public string Barcode { get; set; }

        public override async Task<List<Product>> Execute()
        {
            return await _productRepository.GetAll()
                .FilterByName(Name)
                .FilterByBarcode(Barcode)
                .FilterById(Id)
                .ToListAsync();
        }
    }
}
