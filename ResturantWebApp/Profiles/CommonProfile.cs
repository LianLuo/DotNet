using AutoMapper;
using ResturantWebApp.Models;
using ResturantWebApp.Dtos;

namespace ResturantWebApp.Profiles
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            // CustomerEntity --> CustomerReadDto
            CreateMap<CustomerEntity, CustomerReadDto>()
            .ForMember(dest => dest.CustomerID, opt => opt.MapFrom(src => src.ID));

            CreateMap<CustomerEditDto, CustomerEntity>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.CustomerID))
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender));

            CreateMap<ItemEntity, ItemReadDto>()
            .ForMember(dest => dest.ItemID, opt => opt.MapFrom(src => src.ID));

            CreateMap<ItemEditDto, ItemEntity>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ItemID));

            CreateMap<PaymentEntity, PaymentReadDto>()
            .ForMember(dest => dest.PaymentID, opt => opt.MapFrom(src => src.ID));

            CreateMap<PaymentEditDto, PaymentEntity>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.PaymentID))
            .ForMember(dest => dest.PayMethod, opt => opt.MapFrom(src => src.PayMethod))
            .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyName));
        }
    }
}