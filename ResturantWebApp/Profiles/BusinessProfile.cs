using AutoMapper;
using ResturantWebApp.Dtos;
using ResturantWebApp.Models;

namespace ResturantWebApp.Profiles
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<OrderEditDto, OrderEntity>()
            //.ForMember(dest=>dest.ID, opt => opt.MapFrom(src => src.OrderID))
            .ForMember(dest=>dest.CustomerID, opt => opt.MapFrom(src => src.CustomerID))
            .ForMember(dest=>dest.OrderNumber, opt => opt.MapFrom(src => src.OrderNum))
            .ForMember(dest=>dest.Total, opt => opt.MapFrom(src => src.TotalRevenu));

            CreateMap<OrderItemEditDto, OrderItemEntity>()
            .ForMember(dest=>dest.ItemID, opt => opt.MapFrom(src => src.ItemID))
            .ForMember(dest=>dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<OrderEntity, OrderDetailReadDto>()
            .ForMember(dest=>dest.OrderID, opt => opt.MapFrom(src => src.ID))
            .ForMember(dest=>dest.OrderNum, opt => opt.MapFrom(src => src.OrderNumber))
            .ForMember(dest=>dest.TotalRevenu, opt => opt.MapFrom(src => src.Total));
        }
    }
}