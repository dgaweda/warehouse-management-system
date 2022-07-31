using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Enums;
using DataAccess.Repository.LocationRepository;

namespace DataAccess.CQRS.Query.LocationQueries
{
    public class GetLocationsByTypeQuery : QueryBase<List<Location>>
    {
        public LocationType LocationType { get; set; }

        private readonly ILocationRepository _locationRepository;

        public GetLocationsByTypeQuery(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public override async Task<List<Location>> Execute()
        {
            return await _locationRepository.GetLocationsByType(LocationType);
        }
    }
}
