using FluentValidation.AspNetCore;
using MediatR;
using MercadinhoWeb.Application.Commands.Requests;
using MercadinhoWeb.Application.Commands.Responses;
using MercadinhoWeb.Application.Handlers.CommandHandlers;
using MercadinhoWeb.Domain.Interfaces.Caching;
using MercadinhoWeb.Domain.Interfaces.Repositories;
using MercadinhoWeb.Infra.Data.Caching;
using MercadinhoWeb.Infra.Data.Context;
using MercadinhoWeb.Infra.Data.Repositories;
using MercadinhoWeb.Infra.Ioc.AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace MercadinhoWeb.Infra.Ioc.DependencyInjection;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        #region Banco de dados
        var mySqlConnection = configuration.GetConnectionString("MySqlConnection");
        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(mySqlConnection,
            ServerVersion.AutoDetect(mySqlConnection)));
        #endregion

        #region AutoMapper
        services.AddAutoMapper(typeof(AutoMapperConfiguration));
        #endregion

        #region MediatR
        var assembly = AppDomain.CurrentDomain.Load("MercadinhoWeb.Application");

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        #endregion

        #region FluentValidation
        services.AddFluentValidationAutoValidation();
        #endregion

        #region Caching
        var redisConnection = configuration.GetConnectionString("RedisConnection");
        services.AddStackExchangeRedisCache(o =>
        {
            o.InstanceName = "instance";
            o.Configuration = redisConnection;
        });
        #endregion

        #region Services
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICachingService, CachingService>(x => {
            var redisConfig = configuration.GetSection("RedisConfig");
            var absoluteExpirationRelativeToNow = redisConfig.GetValue<double>("AbsoluteExpirationRelativeToNow");
            var SlidingExpiration = redisConfig.GetValue<double>("SlidingExpiration");

            return new CachingService(x.GetRequiredService<IDistributedCache>(), x.GetRequiredService<ILogger<CachingService>>(), new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(absoluteExpirationRelativeToNow),
                SlidingExpiration = TimeSpan.FromSeconds(SlidingExpiration),

            });
        });

        #endregion
    }
}
