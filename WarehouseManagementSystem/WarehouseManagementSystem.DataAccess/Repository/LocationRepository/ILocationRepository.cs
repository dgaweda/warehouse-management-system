using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.Repository.LocationRepository
{
    public interface ILocationRepository : IRepository<Location>
    {
        Task<List<Location>> GetLocationsByType(LocationType locationType);
        Task<List<Location>> GetLocationsByName(string name);
    }
}