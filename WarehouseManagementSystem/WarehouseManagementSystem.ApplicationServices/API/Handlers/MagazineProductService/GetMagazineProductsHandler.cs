using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.MagazineProductService
{
    public class GetMagazineProductsHandler : IRequestHandler<GetMagazineProductsRequest, GetMagazineProductsResponse>
    {
        private readonly IMapper mapper;

        public GetMagazineProductsHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<GetMagazineProductsResponse> Handle(GetMagazineProductsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
