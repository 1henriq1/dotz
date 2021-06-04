using Dotz.Domain.Interfaces;
using Dotz.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dotz.Domain
{
    public static class Setup
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITokenService, TokenService>();
        }
    }
}
