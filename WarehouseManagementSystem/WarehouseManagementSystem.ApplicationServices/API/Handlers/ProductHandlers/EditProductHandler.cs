﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.DeliveryProductCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using FluentValidation;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Product;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.ProductHandlers
{
    public class EditProductHandler :
        CommandHandler<EditProductRequest, EditProductResponse, Product, Domain.Models.ProductDto, EditProductCommand>,
        IRequestHandler<EditProductRequest, EditProductResponse>
    {
        public EditProductHandler(IMapper mapper, ICommandExecutor commandExecutor,
            IRepository<Product> repositoryService)
            : base(mapper, commandExecutor, repositoryService)
        {
        }

        public async Task<EditProductResponse> Handle(EditProductRequest request, CancellationToken cancellationToken) => await HandleRequest(request);
    }
}
