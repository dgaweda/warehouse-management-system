using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers;
using DataAccess.CQRS.Helpers.DataAccess.Repository;

namespace DataAccess.CQRS.Commands.PalletCommands
{
    public class RemovePalletCommand : CommandBase<Pallet, Pallet>
    {
        public override async Task<Pallet> Execute(WMSDatabaseContext context)
        {
            var deletedPallet = await context.DeleteRecord(Parameter);
            return deletedPallet;
        }
    }
}
