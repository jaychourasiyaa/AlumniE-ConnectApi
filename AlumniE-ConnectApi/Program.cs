using AlumniE_ConnectApi;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Utility;
using AlumniE_ConnectApi.Provider;
using AlumniE_ConnectApi.Provider.Database;
using AlumniE_ConnectApi.Provider.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Bootstrapper.AddBootstapperServices(builder);
AuthenticationDetails.AddAuthenticationDetails(builder);

//adding db context

var connectionString = builder.Configuration.GetConnectionString("connectionString");
builder.Services.AddDbContext<dbContext>(options => options.UseSqlServer(connectionString));
//var emailConfiguration = builder.Configuration.GetSection("Email").Get<EmailConfiguration>();
builder.Services.Configure<EmailConfiguration>(builder.Configuration.GetSection("Email"));
builder.Services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<EmailConfiguration>>().Value);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

/*app.UseCors("MyPolicy");
app.UseDeveloperExceptionPage();
app.UseRouting();*/


