using System.ComponentModel;
using DataAccess.Entities.EntityBases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Role : EntityBase
    {
        [Required]
        [MaxLength(50)]
        [Column("Nazwa roli")]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("Opis roli")]
        public string Description { get; set; }

        [Required]
        [Column("Wynagrodzenie")]
        public decimal Salary { get; set; }
    }
}
