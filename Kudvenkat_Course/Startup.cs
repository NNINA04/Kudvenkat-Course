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

            //DefaultFilesOptions defaultFilesOptions = CreateAndGetDefaultFilesOptions("default");

            //app.UseDefaultFiles(defaultFilesOptions); // Установка 
            //app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();

            //app.Run(async (context) => // Вызывается в случае некорректного адресса в html
            //{
            //    await context.Response.WriteAsync("H W!");
            //});
        }

        private DefaultFilesOptions CreateAndGetDefaultFilesOptions(params string[] names)
        {
            DefaultFilesOptions defaultFilesOptions = new();
            defaultFilesOptions.DefaultFileNames.Clear(); // Очистка всех дефолтных имён (default & index)

            foreach (string name in names)
                defaultFilesOptions.DefaultFileNames.Add($"{name}.html"); // Добавление новых дефолтных имён

            return defaultFilesOptions;
        }
    }
}
