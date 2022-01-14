using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;

namespace DataAccess.CQRS.Commands.RoleCommands
{
    public class RemoveRoleCommand : CommandBase<Role, Role>
    {
        public override async Task<Role> Execute(WMSDatabaseContext context)
        {
            var deletedRecord = await context.DeleteRecord(Parameter);
            return deletedRecord;
        }
    }
}
