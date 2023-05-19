using AutoMapper;
using FluentValidation;
using JwtDemo.DTOs.ProductDtos;
using JwtDemo.Repository.Abstract;
using JwtDemo.Repository.Context;
using JwtDemo.Repository.Repositories;
using JwtDemo.Repository.UnitOfWorks;
using JwtDemo.Service.Abstract;
using JwtDemo.Service.Manager;
using JwtDemo.Service.Mappings.Helpers;
using JwtDemo.Service.ValidationRules.ProductValidators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JwtDemo.Service.DependencyResolvers;

public static class DependencyExtension
{
    public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        #region LocalSqlServer

        services.AddDbContext<DatabaseContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("LocalSqlServer"));
        });

        #endregion

        #region DI

        // repositories
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IProductRepository, ProductRepository>();

        // services
        services.AddScoped<IProductService, ProductManager>();

        #endregion

        #region FluentValidations

        services.AddTransient<IValidator<ProductAddDto>, ProductAddDtoValidator>();
        services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateDtoValidator>();

        #endregion

        #region AutoMapper

        var profiles = ProfileHelper.GetProfiles();
        var config = new MapperConfiguration(opt =>
        {
            opt.AddProfiles(profiles);
        });
        var mapper = config.CreateMapper();
        services.AddSingleton(mapper);

        #endregion
    }
}
