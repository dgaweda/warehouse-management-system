using System.Security.Cryptography;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.ProductsPallets;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets
{
    public class DecreaseProductAmountRequest : RequestBase, IRequest<DecreaseProductAmountResponse>
    {
        public int PalletId { get; set; }
        
        public int ProductId { get; set; }
        
        public int ProductAmount { get; set; }
    }
}