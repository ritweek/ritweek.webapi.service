using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ritweek.solution.webapi.common.Model;
using ritweek.solution.webapi.db;
using ritweek.solution.webapi.Filter;
using ritweek.solution.webapi.provider;

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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IEmployeeRepository employeeRepository)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Seed initial employee data
                SeedInitialData(employeeRepository);
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

        private void SeedInitialData(IEmployeeRepository employeeRepository)
        {
            // Check if any employees already exist
            if (employeeRepository.GetEmployeesAsync().Result.Any())
            {
                return; // Data already seeded
            }

            // Seed initial employee data
            var employees = new List<Employee>
            {
                new Employee { FirstName = "John", LastName = "Doe", EmailAddress = "john.doe@example.com", Age = 30 },
                new Employee { FirstName = "Jane", LastName = "Smith", EmailAddress = "jane.smith@example.com", Age = 35 },
                new Employee { FirstName = "Bruce", LastName = "Doe", EmailAddress = "bruce.doe@example.com", Age = 30 },
                new Employee { FirstName = "Bruce", LastName = "Smith", EmailAddress = "bruce.smith@example.com", Age = 35 },
                // Add more employee data as needed
            };

            foreach (var employee in employees)
            {
                employeeRepository.AddEmployeeAsync(employee);
            }
        }
    }
}

