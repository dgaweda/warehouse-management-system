using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class MagazineProductsProfile : Profile
    {
        public MagazineProductsProfile()
        {
            CreateMap<MagazineProduct, API.Domain.Models.MagazineProduct>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.ExpirationDate, y => y.MapFrom(z => z.ExpirationDate))
                .ForMember(x => x.Barcode, y => y.MapFrom(z => z.Barcode))
                .ForMember(x => x.UnitPrice, y => y.MapFrom(z => z.UnitPrice));
        }
    }
}
