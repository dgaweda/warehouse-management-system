using DataAccess.Entities.EntityBases;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataAccess.Entities
{
    [Index(nameof(RoleId), IsUnique = false)]
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