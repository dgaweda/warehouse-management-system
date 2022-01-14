using DataAccess.Entities.EntityBases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Product : IEntityBase
    {
        public int Id { get; set; }

        [Required]
        [Column("Data ważności", TypeName = "date")]
        public DateTime ExpirationDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("Nazwa produktu")]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("Kod kreskowy")]
        public string Barcode { get; set; }

        public List<Location> Locations { get; set; }

        public List<ProductPalletLine> PalletLines{ get; set; }
    }
}
