using DataAccess.Entities.EntityBases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Departure : EntityBase
    {
        private DateTime _openingTime;
        private DateTime? _closeTime = null;

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public StateType State { get; set; }

        [DataType(DataType.DateTime)]
        [Column(TypeName = "smalldatetime")]
        public DateTime? CloseTime 
        {
            get => _closeTime; 
            set
            {
                if (State == 0)
                    _closeTime = DateTime.Now;
                else
                    _closeTime = default;
            }
        }

        [DataType(DataType.DateTime)]
        [Column(TypeName = "smalldatetime")]
        public DateTime OpeningTime { 
            get => _openingTime; 
            set => _openingTime = DateTime.Now; 
        }

        public List<Pallet> Pallets { get; set; }
    }
    public enum StateType
    {
        CLOSED,
        OPEN
    }
}
