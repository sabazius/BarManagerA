using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarManagerA.BL.Interfaces;
using BarManagerA.BL.Services;
using BarManagerA.DL.Interfaces;
using BarManagerA.DL.Repositories.InMemoryRepos;
using BarManagerA.DL.Repositories.MongoRepos;
using BarManagerA.Host.Extensions;
using BarManagerA.Models.Configuration;
using FluentValidation.AspNetCore;
using Serilog;
using ILogger = Serilog.ILogger;

namespace BarManagerA
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
            services.AddSingleton(Log.Logger);
                       
            services.AddSingleton<IClientRepository, ClientInMemoryRepository>();
            services.AddSingleton<IBillRepository, BillMongoRepository>(); //Dimitar Chervenkov
            services.AddSingleton<IProductsRepository,ProductsMongoRepository>(); // Konstantin Kostov
            services.AddSingleton<IEmployeeRepository, EmployeeMongoRepository>(); // Simeon Shumanov
            services.AddSingleton<IClientTableRepository, ClientTableMongoRepository>(); //Denitsa Angelieva

            services.AddSingleton<ITagRepository, TagMongoRepository > ();


            services.AddSingleton<ITagService, TagService>();
            services.AddSingleton<IProductsService, ProductsService>();
            services.AddSingleton<IBillService, BillService>();
            services.AddSingleton<IProductsService, ProductsService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IClientTableService, ClientTableService>();
            
            services.AddAutoMapper(typeof(Startup));

            services.Configure<MongoDbConfiguration>(Configuration.GetSection(nameof(MongoDbConfiguration)));

            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BarManagerA", Version = "v1" });
            });

            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BarManagerA v1"));
            }

            app.ConfigureExceptionHandler(logger);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
