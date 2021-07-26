using BusinessLayer.Models;
using DataModel.Models;
using HrSystem.Database;
using HrSystem.Datbase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HrSystem.Datbase
{
    public class VacationDbContext : DbContext
    {
        public VacationDbContext(DbContextOptions<VacationDbContext> options) : base(options) { }

        public VacationDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DbConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<EmployeeDto> Employees { get; set; }
        public DbSet<VacationDto> Vacations { get; set; }
        public DbSet<PermissionDto> Permissions { get; set; }
     
    }

}


public class SwcContextFactory : IDesignTimeDbContextFactory<VacationDbContext>
{
    public SwcContextFactory()
    {
    }

    private IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

    public VacationDbContext CreateDbContext(string[] args)
    {

        var builder = new DbContextOptionsBuilder<VacationDbContext>();
        builder.UseSqlServer(Configuration.GetConnectionString("DbConnection"));

        return new VacationDbContext(builder.Options);
    }
}
