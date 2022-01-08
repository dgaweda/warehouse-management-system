using DataAccess.Entities.EntityBases;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Seniority : IEntityBase
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime EmploymentDate { get; set; }
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
