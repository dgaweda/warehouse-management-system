using DataAccess.Entities.EntityBases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Employee : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public int RoleId { get; set; }
        public Seniority Seniority { get; set; }
        public Role Role { get; set; }
    }
}