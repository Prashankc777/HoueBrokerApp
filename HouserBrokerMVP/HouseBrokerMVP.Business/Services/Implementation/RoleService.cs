using AutoMapper;
using HouseBrokerMVP.Business.DTO;
using HouseBrokerMVP.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HouseBrokerMVP.Business.Services
{
    public class RoleService(IAuthRepository authRepository, IMapper mapper) : IRoleService
    {
        public async Task<IEnumerable<RoleListDto>> GetRoleList()
        {
            var data = await authRepository.GetAllRoles().ToListAsync();
            return mapper.Map<IEnumerable<RoleListDto>>(data);
        }
    }
}
