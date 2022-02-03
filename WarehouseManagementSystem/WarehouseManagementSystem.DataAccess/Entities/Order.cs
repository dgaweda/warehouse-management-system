using DataAccess.Entities.EntityBases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Order : IEntityBase
    {
        public int Id { get; set; }
        [Column("Stan zamówienia")]
        public State OrderState { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("Kod kreskowy")]
        public string Barcode { get; set; }

        [Column("Czas rozpoczęcia zamówienia", TypeName = "smalldatetime")]
        public DateTime? PickingStart { get; set; }

        [Column("Czas zakończenia zamówienia", TypeName = "smalldatetime")]
        public DateTime? PickingEnd { get; set; }

        public List<OrderLine> OrderLines { get; set; }
        public List<Pallet> Pallets { get; set; }
    }

    public enum State
    {
        RECEIVED,
        IN_PROGRESS,
        READY_FOR_DEPARTURE,
        SENT
    }
}
