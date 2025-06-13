global using HouseBrokerMVP.Core.Model;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
global using System.IdentityModel.Tokens.Jwt;
global using System.Text;
global using HouseBrokerMVP.Business.DTO;
global using HouseBrokerMVP.Business.Services;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using HouseBrokerMVP.Business.Services.FilePathProvider;
global using System.Net;
global using HouseBrokerMVP.Core.Context;
global using Microsoft.EntityFrameworkCore;
global using HouseBrokerMVP.API;
global using HouseBrokerMVP.API.ExcepitonHandler;
global using HouseBrokerMVP.API.MigrationManager;
global using HouseBrokerMVP.Business;
global using HouseBrokerMVP.Infrastructure;
global using Microsoft.Extensions.FileProviders;

namespace HouseBrokerMVP.API
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Swagger
            services.AddSwaggerGen(s =>
            {
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "LOGIN",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                });
                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                    });
            });

            services.AddEndpointsApiExplorer();

            var jwtConfig = configuration.GetSection("JwtConfig").Get<JwtConfig>()!;
            services.AddSingleton((x) => jwtConfig);
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Policy for CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllAllowPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            //JWT Related
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.RequireAuthenticatedSignIn = true;
            })
             .AddJwtBearer(cfg =>
             {
                 cfg.RequireHttpsMetadata = false;
                 cfg.SaveToken = true;
                 cfg.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidIssuer = jwtConfig.Issuer,
                     ValidateIssuer = true,
                     ValidateLifetime = true,
                     ValidAudience = jwtConfig.Issuer,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key)),
                     ClockSkew = TimeSpan.Zero,
                 };
             });
            return services;
        }
    }
}
