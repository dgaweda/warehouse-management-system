﻿using MediatR;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.User
{
    public class RemoveUserResponse : ResponseBase<Unit>
    {
        public RemoveUserResponse()
        {
            Response = Unit.Value;
        }
    }
}
