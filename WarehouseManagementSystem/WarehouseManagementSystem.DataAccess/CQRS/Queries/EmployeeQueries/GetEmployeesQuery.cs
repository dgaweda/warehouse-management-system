using DataAccess.CQRS.Queries.EmployeeQueries;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DataAccess.CQRS.Queries
{
    public class GetEmployeesQuery : QueryBase<List<Employee>>
    {
        public readonly IGetEntityHelper<Employee> _helper;
        public GetEmployeesQuery(IGetEntityHelper<Employee> helper)
        {
            _helper = helper;
        }

        public override async Task<List<Employee>> Execute(WMSDatabaseContext context)
        {
            if (_helper.PropertiesAreEmpty())
                return await context.Employees.Include(x => x.Role).Include(x => x.Seniority).ToListAsync();
            else
                return await _helper.GetFilteredData(context);
        }
    }
}