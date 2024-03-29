﻿using System;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class LocationDto
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int CurrentAmount { get; set; }
        public int MaxAmount { get; set; }
        public string ProductName { get; set; }
        public Guid? PalletId { get; set; }
    }
}
