using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Seeders.Data;
using FluentAssertions;
using Xunit;

namespace WMS.DataAccess.Test.Extensions.InvoiceExtensionTests
{
    public class InvoiceExtensionTests
    {
        public static IEnumerable<object[]> SetInvoiceNumberTestData()
        {
            yield return new object[]
            {
                new Invoice()
                {
                    Provider = "TEST 2",
                    CreationDate = new DateTime(2021, 3, 1)
                },
                DummyInvoice.GetDummyInvoices(),
                "FV/2/TEST 2/1/3/2021"
            };
            yield return new object[]
            {
                new Invoice()
                {
                    Provider = "TEST",
                    CreationDate = new DateTime(2022, 5, 3)
                },
                DummyInvoice.GetDummyInvoices(),
                "FV/2/TEST/3/5/2022"
            };
            yield return new object[]
            {
                new Invoice()
                {
                    Provider = "TEST 3",
                    CreationDate = new DateTime(2022, 5, 3)
                },
                DummyInvoice.GetDummyInvoices(),
                "FV/1/TEST 3/3/5/2022"
            };
            yield return new object[]
            {
                new Invoice()
                {
                    Provider = "",
                    CreationDate = new DateTime(2022, 5, 3)
                },
                DummyInvoice.GetDummyInvoices(),
                "FV/1//3/5/2022"
            };
        }

        [Theory]
        [MemberData(nameof(SetInvoiceNumberTestData))]
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