using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pokemon.Common.Configuration;
using Pokemon.Common.Data;

namespace Pokemon.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionStringSettings = new ConnectionStringsSettings();
            Configuration.Bind("ConnectionStrings", connectionStringSettings);
            
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<PokemonContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString(connectionStringSettings.DefaultConnection)));

            services.AddControllers();
            services.AddApiVersioning();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
