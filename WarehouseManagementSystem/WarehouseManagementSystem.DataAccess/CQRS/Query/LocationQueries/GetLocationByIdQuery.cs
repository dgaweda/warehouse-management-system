using System.Threading.Tasks;
using DataAccess.CQRS.Query.Queries;
using DataAccess.Entities;
using DataAccess.Repository.LocationRepository;

namespace DataAccess.CQRS.Query.LocationQueries
{
    public class GetLocationByIdQuery : QueryBase<Location, ILocationRepository>
    {
        public int Id { get; set; }
        public override async Task<Location> Execute(ILocationRepository locationRepository)
        {
            return await locationRepository.GetByIdAsync(Id);
        }
    }
}