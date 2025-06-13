using AutoMapper;
using HouseBrokerMVP.Business.DTO;
using HouseBrokerMVP.Core.Entities;

namespace HouseBrokerMVP.Business.Mapper
{
    public class PropertyMapper : Profile
    {
        public PropertyMapper()
        {
            CreateMap<PropertyImage, string>().ConvertUsing(x=>x.ImageName);
            CreateMap<Property, PropertyListDto>().ForMember(x=>x.Images,y=>y.MapFrom(z=>z.PropertyImages));
            CreateMap<PropertyInsertDto, Property>();
            CreateMap<PropertyUpdateDto, Property>();
            CreateMap<PropertyImage, PropertyImageListDto>();
            
        }
    }
}
