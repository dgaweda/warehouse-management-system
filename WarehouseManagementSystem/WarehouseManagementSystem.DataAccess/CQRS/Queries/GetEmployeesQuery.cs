﻿using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries
{
    public class GetEmployeesQuery : QueryBase<List<Employee>>
    {
        public override async Task<List<Employee>> Execute(WMSDatabaseContext context)
        {
            var employees = await context.Employees.ToListAsync();
            return employees;
        }
    }
}