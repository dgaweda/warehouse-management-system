using DataAccess.Entities.EntityBases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Order : EntityBase
    {
        public State State { get; set; }

        [Required]
        [MaxLength(10)]
        public string Barcode { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? PickingStart { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? PickingEnd { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public List<Pallet> Pallets { get; set; }
    }
    
    public enum State
    {
        RECEIVED,
        IN_PROGRESS,
        READY_FOR_DEPARTURE,
        SENT,
        DELIVERED
    }
}
