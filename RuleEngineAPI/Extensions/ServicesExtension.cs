using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RuleEngineAPI.Infrastructure.Middleware;
using Search.Infrastructure.Repositories;
using System;

namespace RuleEngineAPI.Extensions
{
    public static class ServicesExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public static void RegisterMVC(this IServiceCollection service)
        {

            service.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            service.AddMediatR(typeof(Startup));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public static void RegisterDependencies(this IServiceCollection service)
        {

            service.AddScoped<RuleEngineExceptionHandler>();
            
            
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public static void RegisterSwagger(this IServiceCollection service)
        {

            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Rule Engine API",
                    Description = "Applies the specific promitional policy ",
                    TermsOfService = new Uri("https://goplex.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Vikram Singh",
                        Email = "vikram.singh@goplex.com",
                       
                    }
                });
            });
        
        }
    }
}
