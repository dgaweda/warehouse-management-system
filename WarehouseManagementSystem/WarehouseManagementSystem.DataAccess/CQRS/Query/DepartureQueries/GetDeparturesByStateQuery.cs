using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.CQRS.Query.Queries;
using DataAccess.Entities;
using DataAccess.Repository.DepartureRepository;

namespace DataAccess.CQRS.Queries.DepartureQueries
{
    public class GetDeparturesByStateQuery : QueryBase<List<Departure>, IDepartureRepository>
    {
        public StateType State { get; set; }
        public override async Task<List<Departure>> Execute(IDepartureRepository departureRepository)
        {
            return await departureRepository.GetDeparturesByState(State);
        }
    }
}