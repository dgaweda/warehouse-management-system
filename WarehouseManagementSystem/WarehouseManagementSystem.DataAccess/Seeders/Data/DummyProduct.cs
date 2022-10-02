using System;
using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Seeders.Data
{
    public class DummyProduct
    {
        public static List<Product> GetDummyProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = new Guid("D862FC8A-F852-4844-871B-0446F445EC40"),
                    ExpirationDate = new DateTime(2025, 1, 1),
                    Name = "Apap",
                    Barcode = "111111111"
                },
                new Product()
                {
                    Id = new Guid("1F3509D3-258F-49B8-887E-FB55DD427AC9"),
                    ExpirationDate = new DateTime(2027, 2, 15),
                    Name = "Ibuprom",
                    Barcode = "2222222222"
                },
                new Product()
                {
                    Id = new Guid("DCDD6D03-A28B-4A89-8144-3C9FEDFEFFB7"),
                    ExpirationDate = new DateTime(2023, 3, 25),
                    Name = "CDP Chlorina",
                    Barcode = "3333333333"
                },
                new Product()
                {
                    Id = new Guid("6578B5FA-1021-4385-80F8-2CF8CFB6A971"),
                    ExpirationDate = new DateTime(2026, 4, 18),
                    Name = "Cholinex",
                    Barcode = "4444444444"
                },
                new Product()
                {
                    Id = new Guid("FCAD9ED3-754E-44BE-A453-15F433040B67"),
                    ExpirationDate = new DateTime(2024, 5, 4),
                    Name = "Ibuprofen",
                    Barcode = "5555555555"
                }
            };
        }
    }
}