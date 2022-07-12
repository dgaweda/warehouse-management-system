using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.CQRS.Query.Queries;
using DataAccess.Entities;
using DataAccess.Repository.LocationRepository;

namespace DataAccess.CQRS.Query.LocationQueries
{
    public class GetLocationsByNameQuery : QueryBase<List<Location>, ILocationRepository>
    {
        public string Name { get; set; }

        public override async Task<List<Location>> Execute(ILocationRepository locationRepository)
        {
            return await locationRepository.GetLocationsByName(Name);
        }
    }
}
