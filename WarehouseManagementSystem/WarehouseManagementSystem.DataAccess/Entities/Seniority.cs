using DataAccess.Entities.EntityBases;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Seniority : EntityBase
    {
        [Required]
        [Column("Data zatrudnienia", TypeName = "date")]
        public DateTime EmploymentDate { get; set; }
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
