using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestWithAspNet.Business;
using RestWithAspNet.Business.Implementations;
using RestWithAspNet.Model.Context;
using RestWithAspNet.Repository;
using RestWithAspNet.Repository.Implementations;
using System;

namespace RestWithAspNet
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


            //Database
            var connectionString = "server=localhost;user=root;password=root;database=rest_with_aspnet";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));


            //Versionamento
            services.AddApiVersioning();

            
            //Context
            services.AddDbContext<MySqlContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(connectionString, serverVersion)
            );

            //Injeção de Dependencia
            services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();
            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
