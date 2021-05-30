using BackEndPreguntas.Domain.IRepositories;
using BackEndPreguntas.Domain.IServices;
using BackEndPreguntas.Persistence.ContextNotas;
using BackEndPreguntas.Persistence.Repositories;
using BackEndPreguntas.services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndPreguntas
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
            //services.AddDbContext<AplicationDbContext>(options =>
            //            options.UseSqlServer(Configuration.GetConnectionString("Conexion")));

            services.AddEntityFrameworkSqlite().AddDbContext<notasContext>(item => item.UseSqlite(Configuration.GetConnectionString("Conexion")));
            services.AddControllers();


            //service
            services.AddScoped<INotasService, NotasService>();

            //repository
            services.AddScoped<INotasRepository, NotasFileRepository>();

            //Cors
            services.AddCors(options => options.AddPolicy("AllowWebapp",
                                                 builder => builder.AllowAnyOrigin()
                                                                    .AllowAnyHeader()
                                                                    .AllowAnyMethod()));


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowWebapp");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
