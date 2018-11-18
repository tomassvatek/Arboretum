using System;
using System.Diagnostics;
using System.IO;
using Arboretum.AppCore.Repositories;
using Arboretum.AppCore.Services;
using Arboretum.Infrastructure.Repositories;
using Arboretum.Persistence;
using Arboretum.WebService;
using Arboretum.WebService.HttpClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace Arboretum.API
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
            // Add Mvc framework
            services.AddMvc();

            // Add Arboretum configuration
            ConfigureArboretum(services);

            // Configure Swagger
            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new Info
                //{
                //    Title = "Arboretum client API",
                //    Version = "v1",
                //    Contact = new Contact() { Name = "developer", Email = "virtualarboretum@gmail.com" }
                //});

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "Arboretum.API.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Configure a developer environment 
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c =>
                //{
                //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Arboretum");
                //});
            }

            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();

            app.UseMvc();
        }

        private void ConfigureArboretum(IServiceCollection services)
        {
            // Persistence configuration
            //var connectionString = Configuration["ConnectionString"];
            //services.AddDbContext<ArboretumDbContext>(
            //    builder => builder.UseSqlServer(connectionString));

            // Use SQL Database if in Azure, otherwise, use SQLite
            if (Configuration["ASPNETCORE_ENVIROMENT"] == "Production")
            {
                services.AddDbContext<ArboretumDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MyDbConnection")));
                Debug.WriteLine($"Production: {Configuration.GetConnectionString("MyDbConnection")}");
            }
            else
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<ArboretumDbContext>(options =>
                    options.UseSqlServer(connectionString));    
            }

            // Automatically perform database migration
            services.BuildServiceProvider().GetService<ArboretumDbContext>().Database.Migrate();

            // AppCore services
            services.AddTransient<ITreeService, TreeService>();
            services.AddTransient<IDendrologyService, DendrologyService>();

            // AppCore repositories
            services.AddTransient<ITreeRepository, TreeRepository>();
            services.AddTransient<IDendrologyRepository, DendrologyRepository>();
            services.AddTransient<IRestRepository, RestRepository>();

            // WebService services
            services.AddTransient<IHttpClient, RestClient>();
        }
    }
}
