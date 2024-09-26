using AlumniE_ConnectApi;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Utility;
using AlumniE_ConnectApi.Provider;
using AlumniE_ConnectApi.Provider.Database;
using AlumniE_ConnectApi.Provider.Services;
using CloudinaryDotNet;
using MailKit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();

}));
// Add services to the container.
Bootstrapper.AddBootstapperServices(builder);
AuthenticationDetails.AddAuthenticationDetails(builder);

//cloudinay
builder.Services.Configure<CloudinarySettingsConfiguration>(builder.Configuration.GetSection("Cloudinary"));

// Register Cloudinary
builder.Services.AddSingleton(provider =>
{
    var config = provider.GetRequiredService<IOptions<CloudinarySettingsConfiguration>>().Value;
    return new Cloudinary(new Account(config.CloudName, config.ApiKey, config.ApiSecret));
});
builder.Services.AddScoped<ImageServices>();
//adding db context

var connectionString = builder.Configuration.GetConnectionString("connectionString");
builder.Services.AddDbContext<dbContext>(options => options.UseSqlServer(connectionString));
//var emailConfiguration = builder.Configuration.GetSection("Email").Get<EmailConfiguration>();
builder.Services.Configure<EmailConfiguration>(builder.Configuration.GetSection("Email"));
builder.Services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<EmailConfiguration>>().Value);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseCors("MyPolicy");
app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();


