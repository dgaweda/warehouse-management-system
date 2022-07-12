using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        public SeniorityController(IMediator mediator) 
            : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetSeniorities([FromQuery] GetSenioritiesRequest request) => await Handle<GetSenioritiesRequest, GetSenioritiesResponse>(request);

        [HttpPost]
        public async Task<IActionResult> AddSeniority([FromBody] AddSeniorityRequest request) => await Handle<AddSeniorityRequest, AddSeniorityResponse>(request);

        [HttpPut]
        public async Task<IActionResult> EditSeniority([FromBody] EditSeniorityRequest request) => await Handle<EditSeniorityRequest, EditSeniorityResponse>(request);
    }
}
