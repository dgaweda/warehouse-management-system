using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries
{
    public class GetEmployeeQuery : QueryBase<Employee>
    {
        public int Id { get; set; }

        public override async Task<Employee> Execute(WMSDatabaseContext context)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == Id);
            return employee;
        }
    }
}
