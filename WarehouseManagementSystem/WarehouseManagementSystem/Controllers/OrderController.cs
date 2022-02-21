﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using warehouse_management_system.Controllers.BaseController;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Order;

namespace warehouse_management_system.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ApiControllerBase<OrderController>
    {
        public OrderController(IMediator mediator, ILogger<OrderController> logger) 
            : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("Get/")]
        public Task<IActionResult> GetOrders([FromQuery] GetOrdersRequest request) => Handle<GetOrdersRequest, GetOrdersResponse>(request);
        
        // [HttpPost]
        // [Route("Add/")]
        // public Task<IActionResult> AddOrder([FromBody] AddOrderRequest request) => Handle<AddOrderRequest, AddOrderRequest>(request);
    }
}
