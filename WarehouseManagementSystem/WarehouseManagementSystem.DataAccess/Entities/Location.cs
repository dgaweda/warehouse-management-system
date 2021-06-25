using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Location : EntityBase
    {
        public int? ProductId { get; set; }

        [Required]
        [Range(1, 999)]
        public int Amount { get; set; }

        [Required]
        [Range(1, 999)]
        public int MaxAmount { get; set; }

        public bool Special { get; set; }

        public MagazineProduct MagazineProduct { get; set; }
        public DeliveryProduct DeliveryProduct { get; set; }

    }
}