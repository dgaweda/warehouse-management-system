using DataAccess.Entities;
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
