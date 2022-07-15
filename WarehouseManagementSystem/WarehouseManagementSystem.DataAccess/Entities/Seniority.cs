﻿using DataAccess.Entities.EntityBases;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Seniority : EntityBase
    {
        [Required]
        [Column("Data zatrudnienia", TypeName = "date")]
        public DateTime EmploymentDate { get; set; }
        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
