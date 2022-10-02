using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Seeders.Data;
using FluentAssertions;
using Xunit;

namespace WMS.DataAccess.Test.Extensions.ProductExtensionTests
{
    public class ProductExtensionTests
    {
        [Theory]
        [InlineData("D862FC8A-F852-4844-871B-0446F445EC40")]
        [InlineData("1F3509D3-258F-49B8-887E-FB55DD427AC9")]
        [InlineData("0359F5EC-B804-4085-B12E-9E3ABA546776")]
        public void FilterById_ForSpecifiedGuid_FilteredProduct(string stringGuidValue)
        {
            var dummyProducts = DummyProduct.GetDummyProducts().AsQueryable();
            Guid.TryParse(stringGuidValue, out var id);
            var expected = dummyProducts.FirstOrDefault(x => x.Id == id);

            var result = dummyProducts.FilterById(id).FirstOrDefault();
            
            result.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void FilterById_ForGuidEmpty_AllDummyProducts()
        {
            var dummyProducts = DummyProduct.GetDummyProducts().AsQueryable();

            var result = dummyProducts.FilterById(Guid.Empty);
            
            result.Should().BeEquivalentTo(dummyProducts);
        }
        
        [Fact]
        public void FilterById_ForNull_AllDummyProducts()
        {
            var dummyProducts = DummyProduct.GetDummyProducts().AsQueryable();

            var result = dummyProducts.FilterById(null);
            
            result.Should().BeEquivalentTo(dummyProducts);
        }
    }
}