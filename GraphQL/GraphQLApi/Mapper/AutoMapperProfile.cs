using AutoMapper;
using GraphQLApi.DTOs;
using GraphQLApi.Types;

namespace GraphQLApi.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CvType, CvDTO>();
            cfg.CreateMap<CvDTO, CvType>();
        });
    }
}