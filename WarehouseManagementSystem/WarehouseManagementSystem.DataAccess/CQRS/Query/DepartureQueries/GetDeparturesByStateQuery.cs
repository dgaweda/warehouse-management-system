using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.CQRS.Query;
using DataAccess.CQRS.Query.Queries;
using DataAccess.Entities;
using DataAccess.Repository.DepartureRepository;

namespace DataAccess.CQRS.Queries.DepartureQueries
{
    public class GetDeparturesByStateQuery : QueryBase<List<Departure>>
    {
        public StateType State { get; set; }
        private readonly IDepartureRepository _departureRepository;

        public GetDeparturesByStateQuery(IDepartureRepository departureRepository)
        {
            _departureRepository = departureRepository;
        }

        public override async Task<List<Departure>> Execute()
        {
            return await _departureRepository.GetDeparturesByState(State);
        }
    }
}