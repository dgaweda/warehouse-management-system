using System;
using System.Threading.Tasks;
using DataAccess.CQRS.Query.Queries;
using DataAccess.Entities;
using DataAccess.Repository.LocationRepository;

namespace DataAccess.CQRS.Query.LocationQueries
{
    public class GetLocationByIdQuery : QueryBase<Location>
    {
        public Guid Id { get; set; }

        private readonly ILocationRepository _locationRepository;

        public GetLocationByIdQuery(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public override async Task<Location> Execute()
        {
            return await _locationRepository.GetByIdAsync(Id);
        }
    }
}