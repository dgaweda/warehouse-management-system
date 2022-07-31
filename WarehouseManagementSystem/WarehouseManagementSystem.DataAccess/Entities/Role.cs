using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Role : EntityBase.EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        public int Rank { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        public decimal Salary { get; set; }
    }
}
