﻿using DataAccess.Enums;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.User;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User
{
    public class AddUserRequest : RequestBase, IRequest<AddUserResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public RoleKey RoleId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PESEL { get; set; }
        public int Age { get; set; }
    }
}