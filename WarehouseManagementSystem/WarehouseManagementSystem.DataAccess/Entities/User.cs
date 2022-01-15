using DataAccess.Entities.EntityBases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.Entities
{
    public class User : IEntityBase
    {
        public int Id { get; set; }
        
        [MaxLength(100)]
        [Required]
        [Column("Nazwa użytkownika")]
        public string UserName { get; set; }

        [Required]
        [Column("Hasło")]
        public string Password { get; set; }

        public string Salt { get; set; }

        [MaxLength(100)]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
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

        public Seniority Seniority { get; set; }
        public Role Role { get; set; }
        public List<Pallet> Pallets { get; set; }
    }
}