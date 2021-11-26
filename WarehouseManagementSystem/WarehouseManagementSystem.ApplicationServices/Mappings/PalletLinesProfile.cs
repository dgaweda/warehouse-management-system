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
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Barcode, opt => opt.MapFrom(src => src.Pallet.Barcode))
                .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Pallet.Order))
                .ForMember(dest => dest.Departure, opt => opt.MapFrom(src => src.Pallet.Departure))
                .ForMember(dest => dest.Invoice, opt => opt.MapFrom(src => src.Pallet.Invoice))
                .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.Pallet.Employee))
                .ForMember(dest => dest.ProductAmount, opt => opt.MapFrom(src => src.ProductAmount));
        }
    }
}
