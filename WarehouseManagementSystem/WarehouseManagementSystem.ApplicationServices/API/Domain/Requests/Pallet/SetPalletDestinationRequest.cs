using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet
{
    public class SetPalletDestinationRequest : IRequest<SetPalletDestinationResponse>
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? DepartureId { get; set; }
        public int? EmployeeId { get; set; }
        public int? InvoiceId { get; set; }
    }
}
