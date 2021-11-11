using DataAccess.Entities.EntityBases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Departure : EntityBase
    {

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public StateType State { get; set; }

        [DataType(DataType.DateTime)]
        [Column(TypeName = "smalldatetime")]
        public DateTime? CloseTime { get; set; }

        [DataType(DataType.DateTime)]
        [Column(TypeName = "smalldatetime")]
        public DateTime OpeningTime { get; set; }

        public List<Pallet> Pallets { get; set; }
    }
    public enum StateType
    {
        OPEN,
        CLOSED
    }
}
