using DataAccess.CQRS.Queries.EmployeeQueries;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DataAccess.CQRS.Queries
{
    public class GetEmployeesQuery : QueryBase<List<Employee>>
    {
        public readonly IGetEmployeesHelper _helper;
        public GetEmployeesQuery(IGetEmployeesHelper helper)
        {
            _helper = helper;
        }

        public override async Task<List<Employee>> Execute(WMSDatabaseContext context)
        {
            if (_helper.PropertiesAreEmpty())
                return await context.Employees.ToListAsync();
            else
                return await _helper.GetFilteredQuery(context);
        }
    }
}