using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.LocationRepository;

namespace DataAccess.CQRS.Query.LocationQueries
{
    public class GetLocationsByNameQuery : QueryBase<List<Location>>
    {
        public string Name { get; set; }
        private readonly ILocationRepository _locationRepository;

        public GetLocationsByNameQuery(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public override async Task<List<Location>> Execute()
        {
            return await _locationRepository.GetLocationsByName(Name);
        }
    }
}
