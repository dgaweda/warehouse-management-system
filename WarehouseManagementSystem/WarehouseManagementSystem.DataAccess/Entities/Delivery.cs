using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Delivery : EntityBase
    {
        public DateTime ArrivalDate { get; set; }
        public string CompanyName { get; set; }
        public List<Pallet> Pallets { get; set; }

    }
}
