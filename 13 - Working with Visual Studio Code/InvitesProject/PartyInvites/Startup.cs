using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using PartyInvites.Models;

namespace PartyInvites {
    public class Startup {

        public void ConfigureServices(IServiceCollection services) {
            services.AddTransient<IRepository, EFRepository>();
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
