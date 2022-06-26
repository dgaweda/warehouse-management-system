﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using warehouse_management_system.Controllers.BaseController;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Order;

namespace warehouse_management_system.Controllers
{
    [Authorize]
    [Route("/api/order/")]
    [ApiController]
    public class OrderController : ApiControllerBase
    {
        public OrderController(IMediator mediator) 
            : base(mediator)
        {
        }

        [HttpGet]
        [Route("get/")]
        public Task<IActionResult> GetOrders([FromQuery] GetOrdersRequest request) => Handle<GetOrdersRequest, GetOrdersResponse>(request);
        
        [HttpPost]   
        [Route("add/")]
        public Task<IActionResult> AddOrder([FromBody] AddOrderRequest request) => Handle<AddOrderRequest, AddOrderResponse>(request);
        
        [HttpPut]   
        [Route("edit/")]
        public Task<IActionResult> EditOrder([FromBody] EditOrderRequest request) => Handle<EditOrderRequest, EditOrderResponse>(request);
        
        [HttpDelete]   
        [Route("remove/")]
        public Task<IActionResult> RemoveOrder([FromBody] RemoveOrderRequest request) => Handle<RemoveOrderRequest, RemoveOrderResponse>(request);
    }
}
