using DataAccess.Entities.EntityBases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    [Index(nameof(RoleId), IsUnique = false)]
    public class Employee : IEntityBase
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(11)]
        public string PESEL { get; set; }

        [Required]
        [Range(16, 99)]
        public int Age { get; set; }

        [Required]
        public int RoleId { get; set; }

        public int? UserId { get; set; }
        public Seniority Seniority { get; set; }

        public Role Role { get; set; }
        public List<Pallet> Pallets { get; set; }
    }
}