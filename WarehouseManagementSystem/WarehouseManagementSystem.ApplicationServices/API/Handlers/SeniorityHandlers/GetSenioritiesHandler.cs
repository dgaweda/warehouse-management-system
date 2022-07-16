using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Query.Queries.SeniorityQueries;
using DataAccess.Entities;
using DataAccess.Repository.SeniorityRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Seniority;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.SeniorityHandlers
{
    public class GetSenioritiesHandler :
        QueryManager<List<Seniority>, List<SeniorityDto>>,
        IRequestHandler<GetSenioritiesRequest, GetSenioritiesResponse>
    {
        private readonly ISeniorityRepository _seniorityRepository;
        public GetSenioritiesHandler(IMapper mapper, ISeniorityRepository seniorityRepository) : base(mapper)
        {
            _seniorityRepository = seniorityRepository;
        }

        public async Task<GetSenioritiesResponse> Handle(GetSenioritiesRequest request, CancellationToken cancellationToken)
        {
            var queryResult = await new GetSenioritiesQuery(_seniorityRepository)
            {
                EmploymentDate = request.EmploymentDate,
                UserLastName = request.UserLastName,
                UserFirstName = request.UserFirstName
            }.Execute();
            var response = await CreateResponse<GetSenioritiesResponse>(queryResult);
            return response;
        }
    }
}
