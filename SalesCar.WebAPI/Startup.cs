
using SalesCar.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using SalesCar.Helpers;
using SalesCar.Controllers.Extensions;
using SalesCar.Extensions;

namespace SalesCar.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CarSalesContext>(options =>
 options.UseSqlServer(Configuration.GetConnectionString("AZURE_SQL_CONNECTION")));
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddControllers();
            services.AddApplicationServices();
            services.AddIdentityService(Configuration);
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("*");
                });
            });
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseStatusCodePagesWithReExecute("/error/{0}");
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
