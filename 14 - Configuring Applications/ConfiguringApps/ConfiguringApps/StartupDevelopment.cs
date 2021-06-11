using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ConfiguringApps.Infrastructure;

namespace ConfiguringApps {
    public class StartupDevelopment {

        public void ConfigureServices(IServiceCollection services) {
            services.AddSingleton<UptimeService>();
            services.AddMvc( options =>
                options.EnableEndpointRouting = false
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
