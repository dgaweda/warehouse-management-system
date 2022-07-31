using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities.EntityBase
{
    public abstract class EntityBase
    {
        [Key] public Guid Id { get; set; } = Guid.NewGuid();
    }
}
