using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Delivery : EntityBase
    {
        public DateTime Arrival { get; set; }

        [MaxLength(50)]
        public string CompanyName { get; set; }
        public List<Pallet> Pallets { get; set; }
    }
}
