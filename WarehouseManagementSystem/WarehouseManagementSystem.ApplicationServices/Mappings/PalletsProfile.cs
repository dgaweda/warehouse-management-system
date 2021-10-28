using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class PalletsProfile : Profile
    {
        public PalletsProfile()
        {
            CreateMap<Pallet, API.Domain.Models.Pallet>()
                .ForMember(x => x.Barcode, y => y.MapFrom(z => z.Barcode))
                .ForMember(x => x.OrderId, y => y.MapFrom(z => z.OrderId))
                .ForMember(x => x.DepartureId, y => y.MapFrom(z => z.DepartureId))
                .ForMember(x => x.EmployeeId, y => y.MapFrom(z => z.EmployeeId));
        }
    }
}
