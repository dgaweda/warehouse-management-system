using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class MagazineProduct
    {
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime ExpirationDate { get; set; }

        public string Barcode { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
