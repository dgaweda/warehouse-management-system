using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class User : EntityBase.EntityBase
    {
        [MaxLength(100)]
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [MaxLength(100)]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Lastname { get; set; }

        [Required]
        [MaxLength(11)]
        public string PESEL { get; set; }

        [Required]
        [Range(16, 99)]
        public int Age { get; set; }
        
        public Guid? RoleId { get; set; }

        public Seniority Seniority { get; set; }
        public Role Role { get; set; }
        public List<Pallet> Pallets { get; set; }
    }
}