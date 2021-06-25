using DataAccess.Entities.EntityBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Departure : EntityBase
    {
        public DateTime DepartureTime { get; set; }
        public List<Pallet> Pallets { get; set; }
    }
}
