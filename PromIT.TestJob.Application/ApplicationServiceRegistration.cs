using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PromIT.TestJob.Application.Interfaces;
using PromIT.TestJob.Application.Services;
using PromIT.TestJob.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PromIT.TestJob.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ICommentService, CommentService>();

            return services;
        }
    }
}
