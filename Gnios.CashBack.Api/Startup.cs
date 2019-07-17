using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using FluentValidation;
using Gnios.CashBack.Api.Entities;
using Gnios.CashBack.Api.GenericControllers;
using Gnios.CashBack.Api.ModelTest;
using Gnios.CashBack.Api.Persistence;
using Gnios.CashBack.Api.Persistence.Repository.LiteDB;
using Gnios.CashBack.Api.Spotify;
using Gnios.CashBack.Domain.Album.Dto;
using Gnios.CashBack.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Gnios.CashBack.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidateModelAttribute));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddFluentValidation()
            .AddFeatureController();

            services.AddMemoryCache();

            services.AddSingleton<MemoryCacheService, MemoryCacheService>();
            services.AddSingleton<ClientRest, ClientRest>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapper();
            services.AddSwaggerDocCashbackAPI();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new InjectionsConfigure());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Global exception handler
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";
                        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if (contextFeature != null)
                        {
                            await context.Response.WriteAsync(contextFeature.Error.Message);
                        }
                    });
                });

                app.UseHsts();
            }
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cashback V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AlbumEntity, AlbumDto>().ReverseMap();
        }
    }
}
