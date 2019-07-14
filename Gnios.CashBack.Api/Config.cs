using System;
using System.IO;
using System.Reflection;
using FluentValidation.AspNetCore;
using Gnios.CashBack.Api.GenericControllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Gnios.CashBack.Api
{
    public static class Config
    {
        public static IMvcBuilder AddFluentValidation(this IMvcBuilder mvcBuilder)
        {
            return mvcBuilder.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
        }

        public static IMvcBuilder AddFeatureController(this IMvcBuilder mvcBuilder)
        {
            return mvcBuilder.ConfigureApplicationPartManager(m => m.FeatureProviders.Add(new GenericTypeControllerFeatureProvider()));
        }

        public static void AddSwaggerDocCashbackAPI(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Cashback API",
                    Description = "Api de cashback de vinis",
                    Contact = new OpenApiContact
                    {
                        Name = "Eugênio Tavares",
                        Email = "eugenio00@gmail.com",
                        Url = new Uri("https://github.com/gnios/Gnios.CashBack"),
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

    }
}
