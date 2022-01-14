using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Product;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product
{
    public class SetProductLocationRequest : UserRequestBase, IRequest<SetProductLocationResponse>
    {
        public int LocationId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}
