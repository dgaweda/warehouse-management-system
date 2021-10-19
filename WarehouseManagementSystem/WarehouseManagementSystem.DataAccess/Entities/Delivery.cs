using DataAccess.Entities.EntityBases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Delivery : EntityBase
    {
        [Required]
        [Column(TypeName = "smalldatetime")]
        public DateTime Arrival { get; set; }

        [MaxLength(50)]
        public string CompanyName { get; set; }

        public List<Pallet> Pallets { get; set; }
    }
}
