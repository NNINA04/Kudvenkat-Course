using Kudvenkat_Course.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kudvenkat_Course
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(setupAction => setupAction.EnableEndpointRouting = false);

            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
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
