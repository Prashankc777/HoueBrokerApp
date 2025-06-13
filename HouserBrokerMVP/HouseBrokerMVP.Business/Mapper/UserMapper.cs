using AutoMapper;
using HouseBrokerMVP.Business.DTO;
using HouseBrokerMVP.Core.Entities;

namespace HouseBrokerMVP.Business.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<ApplicationUser, UserDto>();
        }

    }
}
