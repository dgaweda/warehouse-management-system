using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repository.DepartureRepository
{
    public interface IDepartureRepository : IRepository<Departure>
    {
        Task<List<Departure>> GetDeparturesByState(StateType state);
    }
}