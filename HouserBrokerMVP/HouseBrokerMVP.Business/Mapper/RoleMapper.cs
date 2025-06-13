using AutoMapper;
using HouseBrokerMVP.Business.DTO;
using Microsoft.AspNetCore.Identity;

namespace HouseBrokerMVP.Business.Mapper
{
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<IdentityRole, RoleListDto>();
        }

    }
}
