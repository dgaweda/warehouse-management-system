using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Seeders.Data;
using FluentAssertions;
using WMS.DataAccess.Test.Extensions.InvoiceExtensionTests.TestData;
using Xunit;

namespace WMS.DataAccess.Test.Extensions.InvoiceExtensionTests
{
    public class InvoiceExtensionTests
    {
        [Theory]
        [ClassData(typeof(SetInvoiceNumberTestData))]
        public void SetInvoiceNumber_ForSampleInvoices_CorrectInvoiceNumber(Invoice source, List<Invoice> invoices, string expected)
        {
            source.SetInvoiceNumber(invoices);
            source.InvoiceNumber.Should().Be(expected);
        }

        [Fact]
        public void FilterByInvoiceNumber_ForEmptyFilter_AllDummyInvoices()
        {
            var invoices = DummyInvoice.GetDummyInvoices().AsQueryable();

            var result = invoices.FilterByInvoiceNumber("");
            
            result.Should().BeEquivalentTo(invoices);
        }
        
        [Theory]
        [InlineData("TEST 2")]
        [InlineData("test 2")]
        [InlineData("fv/1/test 2/1/3/20")]
        public void FilterByInvoiceNumber_ForSpecifiedFilter_LastDummyInvoice(string filterValue)
        {
            var invoices = DummyInvoice.GetDummyInvoices().AsQueryable();

            var result = invoices.FilterByInvoiceNumber(filterValue).First();
            
            result.Should().BeEquivalentTo(invoices.Last());
        }
    }
}