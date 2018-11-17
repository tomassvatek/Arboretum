using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Arboretum.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Arboretum.API.Config
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ArboretumDbContext>
    {
        public ArboretumDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
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
