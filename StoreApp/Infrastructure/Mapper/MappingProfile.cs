using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace StoreApp.Infrastructure.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductDtoForInsertions, Product>();
        CreateMap<ProductDtoForUpdate,Product>().ReverseMap();
    }
}