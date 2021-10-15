﻿using DataAccess.Entities.EntityBases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Location : EntityBase
    {
        public int? DeliveryProductId { get; set; }
        public int? MagazineProductId { get; set; }

        [Required]
        public Type Type { get; set; }

        [MaxLength(10)]
        public string Name { get; set; }

        [Required]
        [Range(1, 999)]
        public int CurrentAmount { get; set; }

        [Required]
        [Range(1, 999)]
        public int MaxAmount { get; set; }

        public DeliveryProduct DeliveryProduct { get; set; }

        public MagazineProduct MagazineProduct { get; set; }

    }

    public enum Type
    {
        NORMAL,
        SHORT_DATE,
        FRIDGE  
    }
}