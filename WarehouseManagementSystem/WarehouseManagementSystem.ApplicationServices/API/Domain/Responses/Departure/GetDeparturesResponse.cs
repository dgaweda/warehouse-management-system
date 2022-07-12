using System.Collections.Generic;
using DataAccess.Repository.DepartureRepository;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure
{
    public class GetDeparturesResponse : ResponseBase<List<DepartureDto>>
    {
    }
}
