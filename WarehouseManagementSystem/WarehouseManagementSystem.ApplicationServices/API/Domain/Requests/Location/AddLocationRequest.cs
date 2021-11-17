using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location
{
    public class AddLocationRequest : IRequest<AddLocationResponse>
    {
        public int? DeliveryProductId { get; set; }
        public int? MagazineProductId { get; set; }
        public DataAccess.Entities.Type LocationType { get; set; }
        public string Name { get; set; }
        public int MaxAmount { get; set; }
    }
}
