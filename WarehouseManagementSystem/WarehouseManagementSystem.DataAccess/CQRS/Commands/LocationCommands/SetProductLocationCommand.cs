using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.ProductCommands
{
    public class SetProductLocationCommand : CommandBase<Location, Location>
    {
        public override Task<Location> Execute(WMSDatabaseContext context)
        {
            throw new NotImplementedException();
        }


    }
}
