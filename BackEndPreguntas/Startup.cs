using BackEndPreguntas.Domain.IRepositories;
using BackEndPreguntas.Domain.IServices;
using BackEndPreguntas.Domain.Models;
using BackEndPreguntas.Middleware;
using BackEndPreguntas.Persistence.ContextNotas;
using BackEndPreguntas.Persistence.Repositories;
using BackEndPreguntas.services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

            services.AddControllers();

                var jwtTokenConfig = new JwtTokenConfig();
                jwtTokenConfig.Secret = "xecretKeywqejannjjnakdADWe";
                jwtTokenConfig.Audience = "http://localhost:4200/inicio";
                jwtTokenConfig.Issuer = "http://localhost:60691/api";
                jwtTokenConfig.AccessTokenExpiration = 10000;
                jwtTokenConfig.RefreshTokenExpiration = 50000;

                 services.AddSingleton(jwtTokenConfig);




            //Conexion con una BD SQLlite
            services.AddEntityFrameworkSqlite().AddDbContext<notasContext>(item => item.UseSqlite(Configuration.GetConnectionString("Conexion")));
            //services.AddControllers();


            //service
            services.AddScoped<INotasService, NotasService>();
            services.AddTransient<INotasAddService, NotasAddService>();
            services.AddTransient<INotasGetService, NotasGetService>();
            services.AddTransient<INotasUpdateService, NotasUpdateService>();
            services.AddTransient<INotasDeleteService, NotasDeleteService>();
            services.AddTransient<INotasSearchDateService, NotasSearchDateService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IJwtAuthManager, JwtAuthManager>();

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
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CDCS.NotasService v1"));
            }

            //app.UseCors("AllowWebapp");
            app.UseCors(options => options.AllowAnyOrigin()
                .AllowAnyHeader().AllowAnyMethod().WithExposedHeaders("Token", "RefreshToken"));

            app.UseMiddleware<JwtMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
