using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Enums;

namespace DataAccess.Repository.DepartureRepository
{
    public interface IDepartureRepository : IRepository<Departure>
    {
        Task<List<Departure>> GetDeparturesByState(StateType state);
    }
}