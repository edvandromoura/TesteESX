using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Modelo.Infra.Data.Context;
using System;

namespace Modelo.Application
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<SQLServerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            //services.AddTransient<IValidator<Patrimonio>, UsuarioValidator>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = $"Patrimonio - API - Desenvolvimento",
                    Version = DateTime.Now.ToString(),
                    Description = "API utilizada para controle de Patrimônios.",

                });

                c.IncludeXmlComments($"{System.AppDomain.CurrentDomain.BaseDirectory}Modelo.Application.xml");
                c.IncludeXmlComments($"{System.AppDomain.CurrentDomain.BaseDirectory}Modelo.Domain.xml");

                c.DescribeAllEnumsAsStrings();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app
                    .UseSwagger()
                    .UseSwaggerUI(c =>
                    {
                        c.DocumentTitle = "Patriomonio API";
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Patriomonio - API V1");
                    });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
