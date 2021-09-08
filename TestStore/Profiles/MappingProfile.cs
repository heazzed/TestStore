using System;
using AutoMapper;
using TestStore.Entities;
using TestStore.EntitiesDto;

namespace TestStore.WebApi.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<OrderProduct, OrderProductDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<Client, ClientDto>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
