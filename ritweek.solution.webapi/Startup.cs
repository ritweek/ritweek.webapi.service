using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ritweek.solution.webapi.db;
using ritweek.solution.webapi.Filter;
using ritweek.solution.webapi.provider;
using System;

namespace ritweek.solution.webapi
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EmployeeDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "EmployeeDatabase"));
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            //services.AddScoped<ExceptionFilterAttribute>();
            services.AddLogging();

            services.AddControllers(options =>
            {
                options.Filters.Add<ExceptionFilter>();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Employee API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API V1");
                });
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

