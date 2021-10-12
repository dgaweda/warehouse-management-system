using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.EntityBases
{
    public class ProductBase : EntityBase
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
    }
}
