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
    [Route("api/seniority/")]
    [ApiController]
    public class SeniorityController : ApiControllerBase
    {
        public SeniorityController(IMediator mediator, IPrivilegesService privileges) 
            : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetSeniorities([FromQuery] GetSenioritiesRequest request) => await Handle<GetSenioritiesRequest, GetSenioritiesResponse>(request);

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddSeniority([FromBody] AddSeniorityRequest request) => await Handle<AddSeniorityRequest, AddSeniorityResponse>(request);

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EditSeniority([FromBody] EditSeniorityRequest request) => await Handle<EditSeniorityRequest, EditSeniorityResponse>(request);
    }
}
