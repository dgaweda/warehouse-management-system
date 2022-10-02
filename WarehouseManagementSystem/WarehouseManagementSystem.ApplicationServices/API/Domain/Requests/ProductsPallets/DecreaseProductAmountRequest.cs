using System;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.ProductsPallets;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets
{
    public class DecreaseProductAmountRequest : RequestBase, IRequest<DecreaseProductAmountResponse>
    {
        public Guid PalletId { get; set; }
        
        public Guid ProductId { get; set; }
        
        public int ProductAmount { get; set; }
    }
}