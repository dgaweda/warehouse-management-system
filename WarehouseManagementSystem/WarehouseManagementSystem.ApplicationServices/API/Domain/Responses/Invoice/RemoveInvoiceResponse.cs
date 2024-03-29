﻿using MediatR;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice
{
    public class RemoveInvoiceResponse : ResponseBase<Unit>
    {
        public RemoveInvoiceResponse()
        {
            Response = Unit.Value;
        }
    }
}
