﻿using System;

namespace WarehouseManagementSystem.ApplicationServices.API.ErrorHandling
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string msg = "Entity not found"): base(msg)
        {
            
        }
    }
}