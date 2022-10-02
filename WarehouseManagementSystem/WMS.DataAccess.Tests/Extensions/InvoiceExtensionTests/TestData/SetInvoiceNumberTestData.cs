using System;
using System.Collections;
using System.Collections.Generic;
using DataAccess.Entities;
using DataAccess.Seeders.Data;

namespace WMS.DataAccess.Test.Extensions.InvoiceExtensionTests.TestData
{
    public class SetInvoiceNumberTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}