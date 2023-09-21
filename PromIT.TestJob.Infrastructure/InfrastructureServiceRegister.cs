using Microsoft.Extensions.DependencyInjection;
using PromIT.TestJob.Application.Interfaces;
using PromIT.TestJob.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromIT.TestJob.Infrastructure
{
    public static class InfrastructureServiceRegister
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, IdentityService>();

            return services;
        }
    }

}
