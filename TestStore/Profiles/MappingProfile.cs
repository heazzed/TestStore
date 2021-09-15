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
            // That works like:
            // CreateMap<Source, Destination>();

            CreateMap<UserDto, User>().ReverseMap();

            CreateMap<ProductDto, Product>().ForMember(prod => prod.Id, o => o.MapFrom(prodDto => prodDto.Id))
               .ForMember(prod => prod.CategoryId, o => o.MapFrom(prodDto => prodDto.CategoryId))
               .ForMember(prod => prod.Category, prodCategory => prodCategory.Ignore()); // Need it?
            CreateMap<Product, ProductDto>().ForMember(prod => prod.Id, o => o.MapFrom(prodDto => prodDto.Id.ToString()))
               .ForMember(prod => prod.CategoryId, o => o.MapFrom(prodDto => prodDto.CategoryId.ToString()));

            CreateMap<CategoryDto, Category>().ForMember(category => category.Id, o => o.MapFrom(category => category.Id));
            CreateMap<Category, CategoryDto>().ForMember(categoryDto => categoryDto.Id, o => o.MapFrom(category => category.Id.ToString()));

            CreateMap<OrderProduct, OrderProductDto>().ForMember(orderProdDto => orderProdDto.OrderId, o => o.MapFrom(orderProd => orderProd.OrderId.ToString()))
                .ForMember(orderProdDto => orderProdDto.Id, o => o.MapFrom(orderProd => orderProd.ProductId.ToString()))
                .ForMember(orderProdDto => orderProdDto.Pieces, o => o.MapFrom(orderProd => orderProd.Pieces));
            CreateMap<OrderProductDto, OrderProduct>().ForMember(orderProd => orderProd.OrderId, o => o.MapFrom(orderProdDto => orderProdDto.OrderId))
                .ForMember(orderProd => orderProd.ProductId, o => o.MapFrom(orderProdDto => orderProdDto.Id))
                .ForMember(orderProd => orderProd.Pieces, o => o.MapFrom(orderProdDto => orderProdDto.Pieces))
                .ForMember(orderProd => orderProd.Product, o => o.Ignore());

            CreateMap<ClientDto, Client>().ForMember(client => client.OrderId, o => o.MapFrom(clientDto => clientDto.OrderId));
            CreateMap<Client, ClientDto>().ForMember(clientDto => clientDto.OrderId, o => o.MapFrom(client => client.OrderId.ToString()));

            CreateMap<OrderDto, Order>()
                .ForMember(order => order.Client, o => o.MapFrom(orderDto => orderDto.Client))
                .ForMember(order => order.Products, o => o.MapFrom(orderDto => orderDto.Products));
            CreateMap<Order, OrderDto>().ForMember(orderDto => orderDto.Id, o => o.MapFrom(order => order.Id.ToString()))
                .ForMember(orderDto => orderDto.Client, o => o.MapFrom(order => order.Client))
                .ForMember(orderDto => orderDto.Products, o => o.MapFrom(order => order.Products));
        }
    }
}
