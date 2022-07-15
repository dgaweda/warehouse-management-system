using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Queries.DepartureQueries;
using DataAccess.Entities;
using DataAccess.Repository.DepartureRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DepartureHandlers
{
    public class GetDeparturesByStateHandler :
        QueryHandler<GetDeparturesByStateQuery, GetDeparturesByStateResponse, List<Departure>, List<DepartureDto>, IDepartureRepository>,
        IRequestHandler<GetDeparturesByStateRequest, GetDeparturesByStateResponse>
    {
        public GetDeparturesByStateHandler(IMapper mapper, IDepartureRepository repository) : base(mapper, repository)
        {
        }

        public async Task<GetDeparturesByStateResponse> Handle(GetDeparturesByStateRequest request, CancellationToken cancellation)
        {
            var query = new GetDeparturesByStateQuery()
            {
                State = request.State
            };
            var response = await HandleQuery(query);
            return response;
        }
    }
}
