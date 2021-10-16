using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.MagazineProductService
{
    public class GetMagazineProductsHandler : HandlerBase<MagazineProduct, Domain.Models.MagazineProduct, GetMagazineProductsResponse, GetMagazineProductsRequest>, IRequestHandler<GetMagazineProductsRequest, GetMagazineProductsResponse>
    {
        private readonly IRepository<MagazineProduct> magazineProductRepository;
        private readonly IMapper mapper;

        public GetMagazineProductsHandler(IRepository<MagazineProduct> magazineProductRepository, IMapper mapper)
        {
            this.magazineProductRepository = magazineProductRepository;
            this.mapper = mapper;
        }

        public async Task<GetMagazineProductsResponse> Handle(GetMagazineProductsRequest request, CancellationToken cancellationToken)
        {
            await SetDomainModel(magazineProductRepository, mapper);
            var response = PrepareResponse();
            return response;
        }
    }
}
