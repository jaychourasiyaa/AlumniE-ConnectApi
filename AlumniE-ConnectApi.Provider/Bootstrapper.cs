using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Utility;
using AlumniE_ConnectApi.Provider.Services;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
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
            builder.Services.AddScoped<ISkillServices, SkillServices>();
            builder.Services.AddScoped<IExperienceServices, ExperienceServices>();
            builder.Services.AddScoped<IJobServices, JobServices>();
            //swagger services
            builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.UseInlineDefinitionsForEnums();
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Alumni E-Connect Api's",
                    Version = "v1"
                });
                //opt.OperationFilter<SwaggerFileOperationFilter>(); // Add this line
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

            //cloudinary
            builder.Services.Configure<CloudinarySettingsConfiguration>(builder.Configuration.GetSection("Cloudinary"));

            // Register Cloudinary
            builder.Services.AddSingleton(provider =>
            {
                var config = provider.GetRequiredService<IOptions<CloudinarySettingsConfiguration>>().Value;
                return new Cloudinary(new Account(config.CloudName, config.ApiKey, config.ApiSecret));
            });
            builder.Services.AddScoped<CloudinaryServices>();

        }
        public class SwaggerFileOperationFilter : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                var fileParams = context.MethodInfo
                    .GetParameters()
                    .Where(p => p.ParameterType == typeof(IFormFile));

                foreach (var param in fileParams)
                {
                    operation.RequestBody.Content["multipart/form-data"] = new OpenApiMediaType
                    {
                        Schema = new OpenApiSchema
                        {
                            Type = "object",
                            Properties =
                    {
                        [param.Name] = new OpenApiSchema
                        {
                            Type = "string",
                            Format = "binary"
                        }
                    }
                        }
                    };
                }
            }
        }


    }
}
