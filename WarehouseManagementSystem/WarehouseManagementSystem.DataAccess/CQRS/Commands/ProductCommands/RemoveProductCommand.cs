﻿using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.DeliveryProductCommands
{
    public class RemoveProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(WMSDatabaseContext context)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == Parameter.Id);

            if (product == null)
                throw new ArgumentNullException();
                
            context.Remove(product);
            await context.SaveChangesAsync();

            return product;
        }
    }
}