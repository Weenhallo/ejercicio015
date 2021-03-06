using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WACines.Repository;
using WACines.Service;

namespace WACines {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<CinesDBContext>();
            services.AddControllers();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Cinema", Version = "v1" });
            });

            services.AddScoped<ISalaService, SalaService>();
            services.AddScoped<ISalaRepository, SalaRepository>();

            services.AddScoped<IPeliculaService, PeliculaService>();
            services.AddScoped<IPeliculaRepository, PeliculaRepository>();

            services.AddScoped<ISesionService, SesionService>();
            services.AddScoped<ISesionRepository, SesionRepository>();

            services.AddScoped<IEntradaService, EntradaService>();
            services.AddScoped<IEntradaRepository, EntradaRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Cinema 1.0.0");
            });
        }
    }
}
