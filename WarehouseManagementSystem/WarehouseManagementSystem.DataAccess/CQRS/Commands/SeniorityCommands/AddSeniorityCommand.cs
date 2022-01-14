using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;

namespace DataAccess.CQRS.Commands.SeniorityCommands
{
    public class AddSeniorityCommand : CommandBase<Seniority, Seniority>
    {
        public override async Task<Seniority> Execute(WMSDatabaseContext context)
        {
            await context.AddRecord(Parameter);

            return Parameter;
        }
    }
}
