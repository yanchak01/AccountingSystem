using AccountingSystem.Domain.Core;
using AccountingSystem.Domain.Interfaces;
using AccountingSystem.Infrastructure.Data;
using AccountingSystem.Services.Classes;
using AccountingSystem.Services.Interfaces;
using AutoMapper;
using System;
using System.Data.Entity;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace AccountingSystem.Services.Utillities
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IRecordRepository, RecordRepository>();
            container.RegisterType<IRecordServices, RecordServices>();
            container.RegisterType<DbContext, AccountingSystemDbEntities1>(new HierarchicalLifetimeManager(), new InjectionConstructor());
            container.RegisterType<IJsonLoadServices, JsonLoadServices>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            container.RegisterInstance<IMapper>(config.CreateMapper());

            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}