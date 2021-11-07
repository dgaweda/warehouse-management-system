using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DataAccess.CQRS.Queries
{
    public class GetEmployeesQuery : QueryBase<List<Employee>>
    {
        private readonly IGetEntityHelper<Employee> _employee;
        public GetEmployeesQuery(IGetEntityHelper<Employee> helper)
        {
            _employee = helper;
        }

        public override async Task<List<Employee>> Execute(WMSDatabaseContext context)
        {
            if (_employee.PropertiesAreEmpty())
                return await context.Employees.Include(x => x.Role).Include(x => x.Seniority).ToListAsync();
            else
                return await _employee.GetFilteredData(context);

        }
    }
}