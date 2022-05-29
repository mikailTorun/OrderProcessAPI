using AutoMapper;
using DataAccess.Entities;
using OrderProcessAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcessAPI.Profiles
{
    public class ProductDtoProfile : Profile
    {
        public ProductDtoProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.Category, operation => operation.MapFrom(src => src.Category))
                .ForMember(dest => dest.Description, operation => operation.MapFrom(src => src.Description))
                .ForMember(dest => dest.Id, operation => operation.MapFrom(src => src.Id))
                .ForMember(dest => dest.Unit, operation => operation.MapFrom(src => src.Unit))
                .ForMember(dest => dest.UnitPrice, operation => operation.MapFrom(src => src.UnitPrice));
                
        }
    }
}
