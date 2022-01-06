using DataAccess.Entities.EntityBases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    [Index(nameof(RoleId), IsUnique = false)]
    public class Employee : EntityBase
    {
        [Required]
        [MaxLength(50)]
        [Column("Imię")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("Nazwisko")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(11)]
        public string PESEL { get; set; }

        [Required]
        [Range(16, 99)]
        [Column("Wiek")]
        public int Age { get; set; }

        [Required]
        public int RoleId { get; set; }

        public int? UserId { get; set; }
        public Seniority Seniority { get; set; }

        public Role Role { get; set; }
        public List<Pallet> Pallets { get; set; }
    }
}