using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests
{
    public class GetDeparturesRequest : UserRequestBase, IRequest<GetDeparturesResponse>
    {
        public string Name { get; set; }
        public DateTime OpeningTime { get; set; }
        public StateType State { get; set; }
    }
}
