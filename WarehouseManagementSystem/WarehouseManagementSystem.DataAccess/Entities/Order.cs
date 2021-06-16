using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Order : EntityBase
    {
        public State State { get; set; }
        public int Barcode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
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
