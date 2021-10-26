using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.EmployeeQueries
{
    public interface IGetEmployeesHelper
    {
        public int EmployeeId { get; set; }
        public string RoleName { get; set; }
        public string PESEL { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public Task<List<Employee>> GetFilteredQuery(WMSDatabaseContext context);
        bool PropertiesAreEmpty();
    }
}