using Microsoft.AspNetCore.Http;

namespace HouseBrokerMVP.Business.Services.FilePathProvider
{
    public class ReadFilePathProviderService(IHttpContextAccessor httpContextAccessor)
        : FilePathProviderService(httpContextAccessor.HttpContext.Request.Scheme + "://" +
                                  httpContextAccessor.HttpContext.Request.Host), IReadFilePathProviderService;
}
