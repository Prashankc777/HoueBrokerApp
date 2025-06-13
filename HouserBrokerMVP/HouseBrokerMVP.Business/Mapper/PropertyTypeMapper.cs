using AutoMapper;
using HouseBrokerMVP.Business.DTO;
using HouseBrokerMVP.Core.Entities;

namespace HouseBrokerMVP.Business.Mapper
{
    public class PropertyTypeMapper : Profile
    {
        public PropertyTypeMapper()
        {
            CreateMap<PropertyType, PropertyTypeListDto>();
            CreateMap<PropertyTypeInsertDto, PropertyType>();
            CreateMap<PropertyTypeUpdateDto, PropertyType>();
        }
    }
}
