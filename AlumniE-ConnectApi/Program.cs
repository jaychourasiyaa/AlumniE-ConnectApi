using AlumniE_ConnectApi;
using AlumniE_ConnectApi.Contract.Utility;
using AlumniE_ConnectApi.Provider;
using AlumniE_ConnectApi.Provider.Database;
using AlumniE_ConnectApi.Provider.Services;
using CloudinaryDotNet;
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
AuthenticationDetails.AddAuthenticationDetails(builder);
Bootstrapper.AddBootstapperServices(builder);

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
app.UseCors("MyPolicy");
app.UseSwagger();
app.UseSwaggerUI();
app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();


