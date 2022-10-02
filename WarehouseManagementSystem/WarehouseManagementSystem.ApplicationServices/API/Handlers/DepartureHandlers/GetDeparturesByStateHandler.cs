using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Query.DepartureQueries;
using DataAccess.Entities;
using DataAccess.Repository.DepartureRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DepartureHandlers
{
    public class GetDeparturesByStateHandler :
        QueryManager<List<Departure>, List<DepartureDto>>,
        IRequestHandler<GetDeparturesByStateRequest, GetDeparturesByStateResponse>
    {
        private readonly IDepartureRepository _repository;
        public GetDeparturesByStateHandler(IMapper mapper, IDepartureRepository repository) : base(mapper)
        {
            _repository = repository;
        }

        public async Task<GetDeparturesByStateResponse> Handle(GetDeparturesByStateRequest request, CancellationToken cancellation)
        {
            var queryResult = await new GetDeparturesByStateQuery(_repository)
            {
                State = request.State
            }.Execute();
            var response = await CreateResponse<GetDeparturesByStateResponse>(queryResult);
            return response;
        }
    }
}
