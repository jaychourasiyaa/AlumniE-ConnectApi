using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Provider.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace AlumniE_ConnectApi.Provider
{
    public class Bootstrapper
    {

        public static void AddBootstapperServices(WebApplicationBuilder builder)
        {
            //Interface Dependency
            builder.Services.AddScoped<IUserServices, UserServices>();
            builder.Services.AddScoped<IAuthorizationServices, AuthorizationServices>();
            builder.Services.AddScoped<IRegionServices, RegionServices>();
            builder.Services.AddScoped<IUniversityServices, UniversityServices>();
            builder.Services.AddScoped<ICollegeServices, CollegeServices>();
            builder.Services.AddScoped<ICourseServices, CourseServices>();
            builder.Services.AddScoped<IEmailServices, EmailServices>();
            builder.Services.AddScoped<IBranchServices, BranchServices>();
            builder.Services.AddScoped<IJwtServices, JwtServices>();
            builder.Services.AddScoped<IEventServices, EventServices>();
            builder.Services.AddScoped<ITagServices, TagServices>();
            builder.Services.AddScoped<IBlogServices, BlogServices>();
            builder.Services.AddScoped<IBlogCommentServices, BlogCommentServices>();
            //swagger services
            builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Alumni E-Connect Api's", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string[]{}
                }
            });
                //opt.OperationFilter<CustomHeaderSwaggerAttribute>();

            });
        }

    }
}
