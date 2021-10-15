using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.Handlers.Base;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.PalletService
{
    public class GetPalletsHandler : HandlerBase<Pallet, Domain.Models.Pallet, GetPalletsResponse, GetPalletsRequest>, IRequestHandler<GetPalletsRequest, GetPalletsResponse>, IGetAll
    {
        private readonly IRepository<Pallet> palletRepository;
        public GetPalletsHandler(IRepository<Pallet> palletRepository)
        {
            this.palletRepository = palletRepository;
        }

        public Task<GetPalletsResponse> Handle(GetPalletsRequest request, CancellationToken cancellationToken)
        {
            PrepareCurrentRepositoryEntity(palletRepository);
            SetDomainModel();
            var response = Service(request, cancellationToken);

            return response;
        }
        public override void SetDomainModel()
        {
            domainModel = entityModel.Select(x => new Domain.Models.Pallet() 
            { 
                Barcode = x.Barcode,
                DeliveryId = x.DeliveryId,
                DepartureId = x.DepartureId,
                EmployeeId = x.EmployeeId,
                OrderId = x.OrderId
            });
        }
    }
}
