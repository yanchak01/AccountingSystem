using AccountingSystem.Domain.Core;
using AccountingSystem.Domain.Interfaces;
using AccountingSystem.Infrastructure.Data;
using AccountingSystem.Services.Classes;
using AccountingSystem.Services.Interfaces;
using AutoMapper;
using Ninject.Modules;
using Ninject.Web.Common;

namespace AccountingSystem.Services.Utillities
{
    public class NinjectRegistrations:NinjectModule
    {
        public override void Load()
        {
            
            Bind<IRecordRepository>().To<RecordRepository>().InRequestScope();
            Bind<IRecordServices>().To<RecordServices>().InRequestScope();
            Bind<AccountingSystemDbEntities>().ToSelf().InRequestScope();
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); });
            Bind<IMapper>().ToConstructor(c => new Mapper(mapperConfiguration)).InSingletonScope();
        }
    }
}
