using Autofac;
using AutoMapper;
using Gnios.CashBack.Api.Entities;
using Gnios.CashBack.Api.Persistence;
using Gnios.CashBack.Api.Persistence.Repository.LiteDB;
using Gnios.CashBack.ApplicationCore.Album;
using Gnios.CashBack.Domain.Album;
using Gnios.CashBack.Domain.Album.Dto;
using Gnios.CashBack.LiteDB.Persistence.CustomRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gnios.CashBack.IoC
{
    public class InjectionsConfigure : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));


            //services.AddSingleton<ILiteDBContext, Context>();
            //services.AddScoped(typeof(IRepository<>), typeof(LiteDBRepository<>));
            builder.RegisterType<Context>()
                   .As<ILiteDBContext>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<Context>()
                   .As<ILiteDBContext>()
                   .InstancePerLifetimeScope();

            builder
                .RegisterGeneric(typeof(BaseBusiness<,>))
                .As(typeof(IBusiness<,>))
                .InstancePerDependency();

            builder.RegisterType<AlbumBusiness>()
                   .As<IBusiness<AlbumEntity, AlbumDto>>()
                   .InstancePerLifetimeScope();

            builder
                .RegisterGeneric(typeof(LiteDBRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerDependency();

            //builder.Register(
            //      ctx =>
            //      {
            //          var scope = ctx.Resolve<ILifetimeScope>();
            //          return new Mapper(ctx.Resolve<IConfigurationProvider>(),scope.Resolve);
            //      })
            //      .As<IMapper>()
            //      .InstancePerLifetimeScope();

            //Type baseEntityType = typeof(IEntity);
            //Assembly assembly = baseEntityType.Assembly;
            //IEnumerable<Type> entityTypes = assembly.GetTypes().Where(x => x.IsSubclassOf(baseEntityType));

            //foreach (Type type in entityTypes)
            //{
            //    builder.RegisterType(typeof(LiteDBRepository<>)
            //           .MakeGenericType(type))
            //           .As(typeof(IRepository<>).MakeGenericType(type))
            //           .InstancePerDependency();
            //}
            //builder.RegisterType<BotCommandsService>()
            //       .As<IStandardCommandService>()
            //       .InstancePerLifetimeScope();
        }
    }
}
