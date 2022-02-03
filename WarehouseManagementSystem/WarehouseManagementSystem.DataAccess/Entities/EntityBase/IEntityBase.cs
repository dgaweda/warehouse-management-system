using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities.EntityBases
{
    public interface IEntityBase
    {
        [Key]
        int Id { get; set; }
    }
}
