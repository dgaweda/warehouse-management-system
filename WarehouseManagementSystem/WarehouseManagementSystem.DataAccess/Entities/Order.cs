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
        public int Barcode { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Start { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Completion { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public List<Pallet> Pallets { get; set; }
    }
    
    public enum State
    {
        Received,
        InProgress,
        ReadyForDeparture,
        Sent,
        Delivered
    }
}
