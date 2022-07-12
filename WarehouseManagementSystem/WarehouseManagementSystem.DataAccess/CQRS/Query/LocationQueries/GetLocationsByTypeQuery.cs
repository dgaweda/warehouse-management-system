using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.CQRS.Query.Queries;
using DataAccess.Entities;
using DataAccess.Repository.LocationRepository;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.CQRS.Query.LocationQueries
{
    public class GetLocationsByTypeQuery : QueryBase<List<Location>, ILocationRepository>
    {
        public LocationType LocationType { get; set; }

        public override async Task<List<Location>> Execute(ILocationRepository locationRepository)
        {
            return await locationRepository.GetLocationsByType(LocationType);
        }
    }
}
