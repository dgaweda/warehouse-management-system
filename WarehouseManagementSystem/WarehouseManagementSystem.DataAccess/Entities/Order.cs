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
        public DateTime? Start { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Completion { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public List<Pallet> Pallets { get; set; }
    }
    
    public enum State
    {
        RECEIVED = 1,
        IN_PROGRESS = 2,
        READY_FOR_DEPARTURE = 3,
        SENT = 4,
        DELIVERED = 5
    }
}
