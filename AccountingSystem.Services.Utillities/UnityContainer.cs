using AccountingSystem.Domain.Core;
using AccountingSystem.Domain.Interfaces;
using AccountingSystem.Infrastructure.Data;
using AccountingSystem.Services.Classes;
using AccountingSystem.Services.Interfaces;
using AutoMapper;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using Unity.Lifetime;

namespace AccountingSystem.Services.Utillities
{
    public static class UnityConfigurations
    {
        public static void RegisterComponent()
        {
            var container = new UnityContainer();

            container.RegisterType<IRecordRepository, RecordRepository>();
            container.RegisterType<IRecordServices, RecordServices>();
            container.RegisterType<DbContext, AccountingSystemDbEntities1>(new HierarchicalLifetimeManager(), new InjectionConstructor());

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            container.RegisterInstance<IMapper>(config.CreateMapper());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
