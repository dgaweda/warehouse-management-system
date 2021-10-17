using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands
{
    public class AddEmployeeCommand : CommandBase<Employee, Employee>
    {
        public override async Task<Employee> Execute(WMSDatabaseContext context)
        {
            await context.Employees.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
