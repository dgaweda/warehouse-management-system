﻿using MediatR;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Order
{
    public class RemoveOrderResponse: ResponseBase<Unit>
    {
        public RemoveOrderResponse()
        {
            Response = Unit.Value;
        }
    }
}