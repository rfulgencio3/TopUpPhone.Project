using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using TopUpPhone.API.Utils;
using TopUpPhone.Application.Services.Interfaces;
using TopUpPhone.Application.Services;
using TopUpPhone.Core.Interfaces;
using TopUpPhone.Infra.Repositories;
using TopUpPhone.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
//builder.Services.AddDbContext<TopUpPhoneDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("TopUpPhoneDb")));

builder.Services.AddDbContext<TopUpPhoneDbContext>(opt =>
    opt.UseInMemoryDatabase("TopUpPhoneDb"));

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBeneficiaryService, BeneficiaryService>();
builder.Services.AddScoped<ITopUpItemService, TopUpItemService>();

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBeneficiaryRepository, BeneficiaryRepository>();
builder.Services.AddScoped<ITopUpItemRepository, TopUpItemRepository>();

// Register IHttpContextAccessor
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IUrlHelperFactory, UrlHelperFactory>();

// Factories
builder.Services.AddSingleton<LinkFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TopUpPhone.API");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
