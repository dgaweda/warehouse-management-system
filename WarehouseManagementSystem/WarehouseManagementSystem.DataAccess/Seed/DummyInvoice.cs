using System;
using System.Collections;
using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Seed
{
    public static class DummyInvoice
    {
        public static IEnumerable<Invoice> GetDummyInvoices()
        {
            var sampleCreationDate1 = new DateTime(2022, 5, 3);
            var sampleCreationDate2 = new DateTime(2021, 3, 1);
            var sampleReceiptDate1 = new DateTime(2021, 3, 2);
            var sampleReceiptDate2 = new DateTime(2021, 4, 12);

            var sampleProvider1 = "TEST";
            var sampleProvider2 = "TEST 2";

            return new[]
            {
                new Invoice()
                {
                    Id = Guid.NewGuid(),
                    InvoiceNumber = $"FV/1/{sampleProvider1}/{sampleCreationDate1.Date.Day}/{ sampleCreationDate1.Date.Month}/{sampleCreationDate1.Date.Year}",
                    Provider = sampleProvider1,
                    CreationDate = sampleCreationDate1,
                    ReceiptDateTime = sampleReceiptDate1,
                    DeliveryId = new Guid("f93239da-4d20-4cb9-a8b7-df9002e4a042")
                },
                new Invoice()
                {
                    InvoiceNumber = $"FV/1/{sampleProvider2}/{sampleCreationDate2.Date.Day}/{ sampleCreationDate2.Date.Month}/{sampleCreationDate2.Date.Year}",
                    Provider = sampleProvider2,
                    CreationDate = sampleCreationDate2,
                    ReceiptDateTime = sampleReceiptDate2,
                    DeliveryId = new Guid("7702b744-7426-4cac-8eb6-d096c8d6cdeb"),
                }
            };
        }
    }
}