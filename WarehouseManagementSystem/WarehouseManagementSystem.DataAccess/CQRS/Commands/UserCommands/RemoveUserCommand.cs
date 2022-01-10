﻿using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;

namespace DataAccess.CQRS.Commands
{
    public class RemoveUserCommand : CommandBase<User, User>
    {

        public override async Task<User> Execute(WMSDatabaseContext context)
        {
            var deletedUser = await context.DeleteRecord(Parameter);
            return deletedUser;
        }
    }
}