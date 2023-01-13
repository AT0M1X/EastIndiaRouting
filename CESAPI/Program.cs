using CESAPI.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using CESAPI.Mappers;
using CESAPI.Service;
using CESAPI.Data;
using CESAPI.Interfaces;
using CESAPI.RoutePlanner;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RoutingContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("RoutingContext")));

builder.Services.AddSingleton<ICityMapper, CityMapperImpl>();
builder.Services.AddSingleton<CityService>();
builder.Services.AddSingleton<PackageTypeService>();
builder.Services.AddSingleton<RoleService>();
builder.Services.AddSingleton<RouteService>();
builder.Services.AddSingleton<ServiceAccountService>();
builder.Services.AddSingleton<FindRouteService>();
builder.Services.AddSingleton<WeightClassService>();
builder.Services.AddSingleton<AuthenticateService>();

builder.Services.AddSingleton<CityDao>();
builder.Services.AddSingleton<PackageTypeDao>();
builder.Services.AddSingleton<WeightClassDao>();
builder.Services.AddSingleton<RouteDao>();
builder.Services.AddSingleton<ServiceAccountDao>();

builder.Services.AddSingleton<ICityMapper, CityMapperImpl>();
builder.Services.AddSingleton<IPackageTypeMapper, PackageTypeMapperImpl>();
builder.Services.AddSingleton<IRoleMapper, RoleMapperImpl>();
builder.Services.AddSingleton<IRouteMapper, RouteMapperImpl>();
builder.Services.AddSingleton<IServiceAccountMapper, ServiceAccountMapperImpl>();
builder.Services.AddSingleton<IWeightClassMapper, WeightClassMapperImpl>();

builder.Services.AddTransient<IRoutePlanner, RoutePlanner>();
builder.Services.AddTransient<IExternalRouteService, ExternalRouteService>();

builder.Services.AddCors(o => o.AddPolicy("MainPolicy", builder =>
{
    builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        //.AllowCredentials()
        .AllowAnyOrigin()
        //.WithOrigins(<Array of corsenabled urls>) // Indsættes fra config.
        ;
}));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("MainPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
