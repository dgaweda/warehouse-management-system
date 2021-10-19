using DataAccess.Entities.EntityBases;
using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Departure : EntityBase
    {
        public DateTime DepartureTime { get; set; }
        public List<Pallet> Pallets { get; set; }
    }
}
