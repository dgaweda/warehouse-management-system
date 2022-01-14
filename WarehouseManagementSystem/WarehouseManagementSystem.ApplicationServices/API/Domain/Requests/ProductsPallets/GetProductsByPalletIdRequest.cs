using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets
{
    public class GetProductsByPalletIdRequest : UserRequestBase, IRequest<GetProductsByPalletIdResponse>
    {
        public int PalletId { get; set; }
    }
}
