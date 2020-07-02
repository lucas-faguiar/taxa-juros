using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using CalculaJuros.API.Interfaces;
using CalculaJuros.API.Services;

namespace CalculaJuros.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", 
                    new OpenApiInfo 
                    { 
                        Title = "Calcula Juros API",
                        Version = "v1",
                        Description = "API REST para calcular juros criada com o ASP.NET Core",
                        Contact = new OpenApiContact
                        {
                            Name = "Lucas Aguiar",
                            Url = new Uri("https://github.com/lucas-faguiar")
                        }
                    });                    
            });       

            // DI COnfiguration
            services.AddScoped<IJurosService, JurosService>();     
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Calcula Juros API");
                c.RoutePrefix = string.Empty;
            });

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
