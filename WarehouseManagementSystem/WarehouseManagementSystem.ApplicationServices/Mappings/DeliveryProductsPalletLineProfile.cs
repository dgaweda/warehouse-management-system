using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class DeliveryProductsPalletLineProfile : Profile
    {
        public DeliveryProductsPalletLineProfile()
        {
            CreateMap<DeliveryProductPalletLine, API.Domain.Models.DeliveryProductPalletLine>()
                .ForMember(dest => dest.Pallet, opt => opt.MapFrom(src => src.Pallet));
        }
    }
}
