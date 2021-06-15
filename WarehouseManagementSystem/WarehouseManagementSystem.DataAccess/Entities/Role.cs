using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Role : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public int Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public decimal Salary { get; set; }

        public Employee Employee { get; set; }
    }
}
