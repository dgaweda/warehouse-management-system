using DataAccess.Entities.EntityBases;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Seniority : EntityBase
    {
        [Required]
        [Column(TypeName = "date")]
        public DateTime EmploymentDate { get; set; }

        public DateTime EmploymentDuration { get; set; }
        public int EmployeeId { get; set; }
    }
}
