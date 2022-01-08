using DataAccess.Entities.EntityBases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [MaxLength(50)]
        [Column("Numer faktury")]
        public string InvoiceNumber { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("Nazwa dostawcy")]
        public string Provider { get; set; }

        [Required]
        [Column("Data i godzina stworzenia faktury", TypeName = "date")]
        public DateTime CreationDate { get; set; }

        [Required]
        [Column("Data i godzina podpisania faktury", TypeName = "smalldatetime")]
        public DateTime ReceiptDateTime { get; set; }

        [Required]
        public int DeliveryId { get; set; }

        public Delivery Delivery { get; set; }
        public List<Pallet> Pallets { get; set; }
    }
}
