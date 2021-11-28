﻿using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.DepartureQueries;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.Departures
{
    public class GetDeparturesHandler :
        QueryHandler<GetDeparturesRequest, GetDeparturesResponse, GetDeparturesQuery, List<Departure>, List<Domain.Models.Departure>>,
        IRequestHandler<GetDeparturesRequest, GetDeparturesResponse>
    {
        public GetDeparturesHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
        {
        }

        public override GetDeparturesQuery CreateQuery(GetDeparturesRequest request)
        {
            var data = new GetDeparturesHelper()
            {
                Name = request.Name,
                OpeningTime = request.OpeningTime,
                State = request.State
            };
            return new GetDeparturesQuery(data);
        }

        public Task<GetDeparturesResponse> Handle(GetDeparturesRequest request, CancellationToken cancellation)
        {
            var query = CreateQuery(request);
            var response = PrepareResponse(query);
            return response;
        }
    }
}