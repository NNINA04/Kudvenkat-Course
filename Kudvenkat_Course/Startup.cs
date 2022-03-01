using Kudvenkat_Course.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kudvenkat_Course
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            string connectionString = _config.GetConnectionString("EmployeeDBConnection");
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));


            services.AddMvc(setupAction => setupAction.EnableEndpointRouting = false).AddXmlSerializerFormatters();
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            // app.UseMvcWithDefaultRoute(); == app.UseMvc(routes => routes.MapRoute("default", "{controller}/{action}/{id}"));

            // controller=class, action=method, id=parameter.
            // Присваивание дефолтных значений, будет означать дефолтной страницей
            app.UseMvc(routes => routes.MapRoute("default", "{controller=Home}/{action=index}/{id?}"));
        }
    }
}
