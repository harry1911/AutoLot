using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoLot.Dal.EfStructures;
using AutoLot.Dal.Initialization;
using AutoLot.Dal.Repos;
using AutoLot.Dal.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoLot.Api
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    options.JsonSerializerOptions.WriteIndented = true;
                });

            var connectionString = Configuration.GetConnectionString("AutoLot");
            services.AddDbContextPool<ApplicationDbContext>(options 
                => options.UseSqlServer(connectionString, sqlOptions 
                    => sqlOptions.EnableRetryOnFailure()));
            // Adding the repos into the DI container
            services.AddScoped<ICarRepo, CarRepo>();
            services.AddScoped<ICreditRiskRepo, CreditRiskRepo>();
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<IMakeRepo, MakeRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env,
            ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                // If in development environment, display debug info
                app.UseDeveloperExceptionPage();
            }
            // Initialize the database
            if (Configuration.GetValue<bool>("RebuildDataBase"))
            {
                SampleDataInitializer.InitializeData(context);
            }
            // redirect http traffic to https
            app.UseHttpsRedirection();
            // opt-in to routing
            app.UseRouting();
            // enable authorization checks
            app.UseAuthorization();
            // opt-in to use endpoint routing
            app.UseEndpoints(endpoints =>
            {
                // use attribute routing on controllers
                endpoints.MapControllers();
            });
        }
    }
}
