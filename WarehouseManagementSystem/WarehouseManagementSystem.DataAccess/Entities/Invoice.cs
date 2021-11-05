using DataAccess.Entities.EntityBases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Invoice : EntityBase
    {
        [Required]
        [MaxLength(20)]
        public string InvoiceNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string Provider { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime InvoiceDate { get; set; }

        [Required]
        [Column(TypeName = "smalldatetime")]
        public DateTime InvoiceReceiptDate { get; set; }

        [Required]
        public int DeliveryId { get; set; }

        public List<Pallet> Pallets { get; set; }
    }
}
