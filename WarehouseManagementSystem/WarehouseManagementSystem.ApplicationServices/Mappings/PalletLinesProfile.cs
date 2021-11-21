using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class PalletLinesProfile : Profile
    {
        public PalletLinesProfile()
        {
            CreateMap<PalletLine, API.Domain.Models.PalletLine>()
                .ForMember(dest => dest.Pallet, opt => opt.MapFrom(src => src.Pallet))
                .ForMember(dest => dest.ProductAmount, opt => opt.MapFrom(src => src.ProductAmount));
        }
    }
}
