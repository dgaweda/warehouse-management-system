﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class OrderRow : EntityBase.EntityBase
    {
        public Guid? ProductId { get; set; }

        public Guid? OrderId { get; set; }

        [Required]
        [Range(1, 999)]
        public int Amount { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }
        
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
