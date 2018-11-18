using System.IO;
using Arboretum.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Arboretum.API.Config
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ArboretumDbContext>
    {
        //// Development
        //public ArboretumDbContext CreateDbContext(string[] args)
        //{
        //    IConfiguration configuration = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.Development.json")
        //        .Build();

        //    var builder = new DbContextOptionsBuilder<ArboretumDbContext>();
        //    var connectionString = configuration.GetConnectionString("DefaultConnection");
        //    builder.UseSqlServer(connectionString);
        //    return new ArboretumDbContext(builder.Options);
        //}

        // Production
        public ArboretumDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ArboretumDbContext>();
            var connectionString = configuration.GetConnectionString("MyDbConnection");
            builder.UseSqlServer(connectionString);
            return new ArboretumDbContext(builder.Options);
        }
    }
}
