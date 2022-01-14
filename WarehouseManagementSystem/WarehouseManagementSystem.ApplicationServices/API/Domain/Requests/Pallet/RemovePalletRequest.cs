using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet
{
    public class RemovePalletRequest : UserRequestBase, IRequest<RemovePalletResponse>
    {
        public int PalletId { get; set; }
    }
}
