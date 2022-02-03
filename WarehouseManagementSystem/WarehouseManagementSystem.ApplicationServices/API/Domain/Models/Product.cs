﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class Product
    {
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime ExpirationDate { get; set; }
        public string Barcode { get; set; }
        public List<ProductPalletLine> PalletLines { get; set; }
    }
}
