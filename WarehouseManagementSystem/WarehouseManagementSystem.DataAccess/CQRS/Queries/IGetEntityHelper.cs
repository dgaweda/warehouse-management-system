using DataAccess.Entities;
using DataAccess.Entities.EntityBases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.EmployeeQueries
{
    public interface IGetEntityHelper<T>
    {
        Task<List<T>> GetFilteredData(WMSDatabaseContext context);
        bool PropertiesAreEmpty();
    }
}