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
    public class Seniority : EntityBase
    {
        [Required]
        [Column(TypeName = "smalldatetime")]
        public DateTime EmploymentDate { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
