using AutoMapper;
using EStore.BusinessObject.Entities;
using EStore.Share.DTOs;

namespace EStore.Share.Profiles
{
    public class MapperProfiles : Profile
    {

        public MapperProfiles()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Member, MemberDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
        }

    }
}
