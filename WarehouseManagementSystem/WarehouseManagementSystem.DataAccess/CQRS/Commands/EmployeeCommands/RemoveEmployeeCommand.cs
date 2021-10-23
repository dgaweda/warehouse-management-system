using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands
{
    public class RemoveEmployeeCommand : CommandBase<Employee, Employee>
    {
        public int EmployeeId { get; set; }

        public override async Task<Employee> Execute(WMSDatabaseContext context)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(employee => employee.Id == EmployeeId);

            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
            return employee;
        }
    }
}
