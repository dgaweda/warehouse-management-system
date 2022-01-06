using DataAccess.Entities.EntityBases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class User : EntityBase
    {
        [MaxLength(100)]
        [Required]
        [Column("Nazwa użytkownika")]
        public string UserName { get; set; }

        [MaxLength(30)]
        [Required]
        [DataType(DataType.Password)]
        [Column("Hasło")]
        public string Password { get; set; }

        [MaxLength(100)]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Employee Employee { get; set; }
    }
}
