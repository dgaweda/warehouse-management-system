﻿using MediatR;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice
{
    public class EditInvoiceRequest : RequestBase, IRequest<EditInvoiceResponse>
    {
        public override Guid Id { get; set; }
        public string Provider { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ReceiptDateTime { get; set; }
        public int DeliveryId { get; set; }
    }
}