using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class OrderLine : EntityBase
    {
        public int ProductId { get; set; }

        public int OrderId { get; set; }

        [Required]
        [Range(0, 999)]
        public int Amount { get; set; }
        
        [Required]
        [DataType(DataType.Currency)]
        [Range(0.1, 9999)]
        public decimal Price { get; set; }

        public Order Order { get; set; }
        public MagazineProduct MagazineProduct { get; set; }
    }
}
