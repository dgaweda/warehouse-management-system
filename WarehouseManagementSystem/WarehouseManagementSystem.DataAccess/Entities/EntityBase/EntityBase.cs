using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities.EntityBases
{
    public abstract class EntityBase
    {
        [Key] 
        public Guid Id { get; set; }
    }
}
