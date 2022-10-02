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
                    ExpirationDate = new DateTime(2025, 1, 1),
                    Name = "Apap",
                    Barcode = "111111111"
                },
                new Product()
                {
                    ExpirationDate = new DateTime(2027, 2, 15),
                    Name = "Ibuprom",
                    Barcode = "2222222222"
                },
                new Product()
                {
                    ExpirationDate = new DateTime(2023, 3, 25),
                    Name = "CDP Chlorina",
                    Barcode = "3333333333"
                },
                new Product()
                {
                    ExpirationDate = new DateTime(2026, 4, 18),
                    Name = "Cholinex",
                    Barcode = "4444444444"
                },
                new Product()
                {
                    ExpirationDate = new DateTime(2024, 5, 4),
                    Name = "Ibuprofen",
                    Barcode = "5555555555"
                }
            };
        }
    }
}