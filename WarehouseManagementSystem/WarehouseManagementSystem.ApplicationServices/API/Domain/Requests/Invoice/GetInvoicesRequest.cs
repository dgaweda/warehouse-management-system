﻿using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice
{
    public class GetInvoicesRequest : RequestBase, IRequest<GetInvoicesResponse>
    {
    }
}