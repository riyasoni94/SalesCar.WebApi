using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SalesCar.Application.IServices;
using SalesCar.Application.Services;
using SalesCar.Core.Interfaces;
using SalesCar.Infrastructure.Models;
using SalesCar.Infrastructure.Repositories;

using System.Linq;

namespace SalesCar.Controllers.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<CarSalesContext, CarSalesContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IBuyerRepository, BuyerRepository>();
            services.AddScoped<IBuyerService, BuyerService>();

            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IUserService, UserService>();

         
            services.Configure<ApiBehaviorOptions>(options =>
              options.InvalidModelStateResponseFactory = ActionContext =>
              {
                  var error = ActionContext.ModelState
                              .Where(e => e.Value.Errors.Count > 0)
                              .SelectMany(e => e.Value.Errors)
                              .Select(e => e.ErrorMessage).ToArray();
                  var errorresponce = new Exception();
                  return new BadRequestObjectResult(error);
              }
            );
            return services;
        }
    }
}
