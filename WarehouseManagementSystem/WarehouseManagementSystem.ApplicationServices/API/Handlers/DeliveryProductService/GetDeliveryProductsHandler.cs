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

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DeliveryProductService
{
    public class GetDeliveryProductsHandler : HandlerBase<DeliveryProduct, Domain.Models.DeliveryProduct, GetDeliveryProductsResponse, GetDeliveryProductsRequest>, IRequestHandler<GetDeliveryProductsRequest, GetDeliveryProductsResponse>, IGetAll
    {
        private readonly IRepository<DeliveryProduct> deliveryProductRepository;

        public GetDeliveryProductsHandler(IRepository<DeliveryProduct> deliveryProductRepository)
        {
            this.deliveryProductRepository = deliveryProductRepository;
        }

        public Task<GetDeliveryProductsResponse> Handle(GetDeliveryProductsRequest request, CancellationToken cancellationToken)
        {
            PrepareCurrentRepositoryEntity(deliveryProductRepository);
            SetDomainModel();
            var response = Service(request, cancellationToken);
            return response;
        }

        public override void SetDomainModel()
        {
            domainModel = entityModel.Select(x => new Domain.Models.DeliveryProduct() 
            { 
                Name = x.Name,
                Amount = x.Amount,
                Barcode = x.Barcode,
                ExpirationDate = x.ExpirationDate,
                PalletId = x.PalletId
            });
        }
    }
}
