using Dotz.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Dotz.Infrastructure.Repositories;
using Dotz.Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Dotz.Infrastructure
{
    public static class Setup
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            var serverVersion = new MySqlServerVersion(new Version(1, 0, 0));
            services.AddDbContext<DotzContext>(options => options.UseMySql(configuration.GetConnectionString("DefaultConnection"), serverVersion));
        }

        public static void AutomaticMigrate<TDbContext>(this IApplicationBuilder app) where TDbContext : DbContext
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<TDbContext>();

            if (context.Database.GetService<IDatabaseCreator>() is RelationalDatabaseCreator)
            {
                var migrations = context.Database.GetPendingMigrations();
                if (migrations.Any())
                    context.Database.Migrate();
            }
        }
    }
}
