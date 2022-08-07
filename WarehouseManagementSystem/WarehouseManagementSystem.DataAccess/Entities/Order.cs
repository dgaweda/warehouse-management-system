using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Enums;

namespace DataAccess.Entities
{
    public class Order : EntityBase.EntityBase
    {
        public OrderState OrderState { get; set; }

        [Required]
        [MaxLength(10)]
        public string Barcode { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? PickingStart { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? PickingEnd { get; set; }

        public List<OrderRow> OrderRows { get; set; }
        public List<Pallet> Pallets { get; set; }
    }
}
