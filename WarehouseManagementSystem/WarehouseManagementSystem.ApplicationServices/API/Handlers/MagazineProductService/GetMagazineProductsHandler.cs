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

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.MagazineProductService
{
    public class GetMagazineProductsHandler : HandlerBase<MagazineProduct, Domain.Models.MagazineProduct, GetMagazineProductsResponse, GetMagazineProductsRequest>, IRequestHandler<GetMagazineProductsRequest, GetMagazineProductsResponse>, IGetAll
    {
        private readonly IRepository<MagazineProduct> magazineProductRepository;

        public GetMagazineProductsHandler(IRepository<MagazineProduct> magazineProductRepository)
        {
            this.magazineProductRepository = magazineProductRepository;
        }

        public Task<GetMagazineProductsResponse> Handle(GetMagazineProductsRequest request, CancellationToken cancellationToken)
        {
            PrepareCurrentRepositoryEntity(magazineProductRepository);
            SetDomainModel();
            var response = Service(request, cancellationToken);
            return response;
        }

        public override void SetDomainModel()
        {
            domainModel = entityModel.Select(x => new Domain.Models.MagazineProduct() 
            { 
                Name = x.Name,
                ExpirationDate = x.ExpirationDate,
                Barcode = x.Barcode,
                UnitPrice = x.UnitPrice
            });
        }
    }
}
