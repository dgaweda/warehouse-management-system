using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class DeliveryProductsProfile : Profile
    {
        public DeliveryProductsProfile()
        {

            CreateMap<DeliveryProduct, API.Domain.Models.DeliveryProduct>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount))
                .ForMember(x => x.ExpirationDate, y => y.MapFrom(z => z.ExpirationDate))
                .ForMember(x => x.Barcode, y => y.MapFrom(z => z.Barcode));

        }
    }
}
