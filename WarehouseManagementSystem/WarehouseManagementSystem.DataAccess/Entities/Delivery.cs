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
        [MaxLength(50)]
        [Column("Nazwa dostawcy")]
        public string Name { get; set; }

        [Required]
        [Column("Data i godzina przyjazdu dostawy", TypeName = "smalldatetime")]
        public DateTime Arrival { get; set; }

        public List<Invoice> Invoices { get; set; }
    }
}
