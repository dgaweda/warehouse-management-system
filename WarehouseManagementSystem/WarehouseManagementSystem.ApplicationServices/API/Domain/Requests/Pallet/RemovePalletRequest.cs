using System;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet
{
    public class RemovePalletRequest : RequestBase, IRequest<RemovePalletResponse>
    {
        public override Guid Id { get; set; }
    }
}