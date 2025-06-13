using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace HouseBrokerMVP.Business.Services
{
    public class CoreService(IHttpContextAccessor httpContextAccessor) : ICoreService
    {
        public string GetLoggedInUserName()
        {
            var user = httpContextAccessor.HttpContext.User ?? throw new Exception("User not found, Please try again");
            var userName = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
            if (userName is null)
                throw new Exception("Please Login to continue");
            return userName.Value;
        }
    }
}
