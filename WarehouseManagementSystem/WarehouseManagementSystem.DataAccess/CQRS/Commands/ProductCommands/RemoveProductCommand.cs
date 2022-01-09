using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;
using Microsoft.VisualBasic.CompilerServices;

namespace DataAccess.CQRS.Commands.DeliveryProductCommands
{
    public class RemoveProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(WMSDatabaseContext context)
        {
            var deletedProduct = await context.DeleteRecord(Parameter);
            return deletedProduct;
        }
    }
}
