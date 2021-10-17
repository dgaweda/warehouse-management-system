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
using WarehouseManagementSystem.ApplicationServices.API.Domain;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public class GetRolesHandler : IRequestHandler<GetRolesRequest, GetRolesResponse>
    { 
        private readonly IMapper mapper;

        public GetRolesHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<GetRolesResponse> Handle(GetRolesRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

