﻿using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands
{
    public class EditEmployeeCommand : CommandBase<Employee, Employee>
    {
        public override async Task<Employee> Execute(WMSDatabaseContext context)
        {
            context.Entry(Parameter).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
