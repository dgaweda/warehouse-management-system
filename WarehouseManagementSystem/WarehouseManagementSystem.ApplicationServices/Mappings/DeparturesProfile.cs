using AutoMapper;
using DataAccess.Entities;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class DeparturesProfile : Profile
    {
        public DeparturesProfile()
        {
            CreateMap<Departure, DepartureDto>();

            CreateMap<RemoveDepartureRequest, Departure>();

            CreateMap<AddDepartureRequest, Departure>();

            CreateMap<EditDepartureStateRequest, Departure>();
        }
    }
}
