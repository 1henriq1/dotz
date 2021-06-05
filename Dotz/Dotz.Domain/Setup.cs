using Dotz.Domain.Interfaces;
using Dotz.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Dotz.Infrastructure.Validators;

namespace Dotz.Domain
{
    public static class Setup
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserRequestValidator>());
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ITokenService, TokenService>();
        }
    }
}
