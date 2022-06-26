using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using warehouse_management_system.Authentication;
using warehouse_management_system.Controllers.BaseController;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Seniority;

namespace warehouse_management_system.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class SeniorityController : ApiControllerBase
    {
        public SeniorityController(IMediator mediator, IPrivilegesService privileges) 
            : base(mediator)
        {
        }

        [HttpGet]
        [Route("All/")]
        public Task<IActionResult> GetSeniorities([FromQuery] GetSenioritiesRequest request) => Handle<GetSenioritiesRequest, GetSenioritiesResponse>(request);

        [HttpPost]
        [Route("Add/")]
        public Task<IActionResult> AddSeniority([FromBody] AddSeniorityRequest request) => Handle<AddSeniorityRequest, AddSeniorityResponse>(request);

        [HttpPut]
        [Route("Edit/")]
        public Task<IActionResult> EditSeniority([FromBody] EditSeniorityRequest request) => Handle<EditSeniorityRequest, EditSeniorityResponse>(request);
    }
}
