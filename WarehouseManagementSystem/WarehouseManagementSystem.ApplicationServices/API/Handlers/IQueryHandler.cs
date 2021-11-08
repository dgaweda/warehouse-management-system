﻿using DataAccess.CQRS.Queries;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public interface IQueryHandler<TRequest, TResponse, TQuery, TResult, TDomainModel>
        where TQuery : QueryBase<TResult>
        where TResponse : ResponseBase<TDomainModel>, new()
    {
        TQuery CreateQuery(TRequest request);
        Task<TResponse> Response(TQuery query);
    }
}