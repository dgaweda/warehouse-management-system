﻿namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        
        public int Age { get; set; }
        public string Role { get; set; }
    }
}
