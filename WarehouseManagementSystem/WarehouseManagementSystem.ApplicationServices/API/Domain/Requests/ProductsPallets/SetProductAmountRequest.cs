using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.ProductsPallets;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets
{
    public class SetProductAmountRequest : IRequest<SetProductAmountResponse>
    {
        public int PalletId { get; set; }
        public int ProductId { get; set; }
        public int ProductAmount { get; set; }
    }
}
