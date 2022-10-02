using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Product : EntityBase.EntityBase
    {
        [Required]
        [Column(TypeName = "date")]
        public DateTime ExpirationDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string Barcode { get; set; }

        public List<Location> Locations { get; set; }

        public List<PalletRow> PalletLines{ get; set; }
    }
}
