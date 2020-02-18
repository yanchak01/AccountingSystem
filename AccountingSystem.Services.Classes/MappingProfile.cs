using AccountingSystem.Domain.Core;
using AccountingSystem.ViewModels.EntitieViewModels;
using AutoMapper;

namespace AccountingSystem.Services.Classes
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Record, RecordsViewModel>().ReverseMap();
        }
    }
}
