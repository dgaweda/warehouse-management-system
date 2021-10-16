using AutoMapper;
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

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.PalletService
{
    public class GetPalletsHandler : HandlerBase<Pallet, Domain.Models.Pallet, GetPalletsResponse, GetPalletsRequest>, IRequestHandler<GetPalletsRequest, GetPalletsResponse>
    {
        private readonly IRepository<Pallet> palletRepository;
        private readonly IMapper mapper;

        public GetPalletsHandler(IRepository<Pallet> palletRepository, IMapper mapper)
        {
            this.palletRepository = palletRepository;
            this.mapper = mapper;
        }

        public Task<GetPalletsResponse> Handle(GetPalletsRequest request, CancellationToken cancellationToken)
        {
            SetDomainModel(palletRepository, mapper);
            var response = PrepareResponse();
            return response;
        }
    }
}
