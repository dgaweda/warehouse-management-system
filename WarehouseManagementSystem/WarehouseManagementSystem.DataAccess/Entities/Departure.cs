using DataAccess.Entities.EntityBases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Departure : EntityBase
    {
        [DataType(DataType.DateTime)]
        [Column(TypeName = "smalldatetime")]
        public DateTime DepartureTime { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<Pallet> Pallets { get; set; }
    }
}
