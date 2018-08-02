using System.IO;
using Arboretum.Core.Repositories;
using Arboretum.Core.Services;
using Arboretum.Core.WebServices.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace Arboretum.API
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddMvc( );

            // Add application services
            services.AddTransient<ITreeService, TreeService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();



            // Configure Swagger
            services.AddSwaggerGen( c =>
            {
                c.SwaggerDoc( "v1", new Info
                {
                    Title = "Arboretum API",
                    Version = "v1",
                    Contact = new Contact( ) { Name = "Tomáš Svatek", Email = "virtualarboretum@gmail.com" }
                } );

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine( basePath, "Arboretum.API.xml" );
                c.IncludeXmlComments( xmlPath );
            } );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IHostingEnvironment env )
        {
            if ( env.IsDevelopment( ) )
            {
                app.UseDeveloperExceptionPage( );
                app.UseDatabaseErrorPage( );
            }

            app.UseSwagger( );
            app.UseSwaggerUI( c =>
            {
                c.SwaggerEndpoint( "/swagger/v1/swagger.json", "Arboretum API V1" );
            } );

            app.UseMvc( );
        }
    }
}
