using AutoMapper;
using JwtDemo.DTOs.ProductDtos;
using JwtDemo.Entities.Concrete;

namespace JwtDemo.Service.Mappings.AutoMapper;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductListDto>().ReverseMap();
        CreateMap<Product, ProductAddDto>().ReverseMap();
        CreateMap<Product, ProductAddedDto>().ReverseMap();
        CreateMap<Product, ProductUpdateDto>().ReverseMap();
    }
}