﻿using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;

namespace DataAccess.CQRS.Commands.DeliveryCommands
{
    public class RemoveDeliveryCommand : CommandBase<Delivery, Delivery>
    {
        public override async Task<Delivery> Execute(WMSDatabaseContext context)
        {
            return await context.DeleteRecord(Parameter);
        }
    }
}
