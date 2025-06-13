using HouseBrokerMVP.Business.Services;
using HouseBrokerMVP.Business.Services.FilePathProvider;
using HouseBrokerMVP.Business.Services.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HouseBrokerMVP.Business
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServicesFromBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IAuthService,AuthService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<ICoreService, CoreService>(); 
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IPropertyTypeService, PropertyTypeService>();
            services.AddTransient<IPropertyService, PropertyService>();

            services.AddScoped<IReadFilePathProviderService, ReadFilePathProviderService>();
            services.AddScoped<ISaveFilePathProviderService, SaveFilePathProviderService>();
            return services;
        }
    }
}
