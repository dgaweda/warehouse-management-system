﻿using DataAccess.Entities.EntityBases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Product : EntityBase
    {
        [Required]
        [Column(TypeName = "date")]
        public DateTime ExpirationDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string Barcode { get; set; }

        public List<Location> Locations { get; set; }

        public List<PalletLine> PalletLines{ get; set; }
    }
}