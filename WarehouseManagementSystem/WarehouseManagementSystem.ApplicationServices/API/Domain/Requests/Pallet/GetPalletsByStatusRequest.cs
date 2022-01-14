using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests
{
    public class GetPalletsByStatusRequest : UserRequestBase, IRequest<GetPalletsByStatusResponse>
    {
        public PalletEnum.Status PalletStatus { get; set; }
    }
}
