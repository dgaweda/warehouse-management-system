using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;

namespace DataAccess.CQRS.Commands.LocationCommands
{
    public class RemoveLocationCommand : CommandBase<Location, Location>
    {
        public override async Task<Location> Execute(WMSDatabaseContext context)
        {
            var deletedLocation = await context.DeleteRecord(Parameter);
            return deletedLocation;
        }
    }
}
