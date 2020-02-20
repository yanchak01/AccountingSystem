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
            CreateMap<RecordJsonModel, RecordsViewModel>()
                .ForMember(ce => ce.UserId, ci => ci.MapFrom(src => src.UserId))
                .ForMember(ce => ce.Tittle, ci => ci.MapFrom(src => src.Title));
            CreateMap<RecordsViewModel, JsonViewModel>()
                .ForMember(ce => ce.Id, ci => ci.MapFrom(src => src.Id))
                .ForMember(ce => ce.UserId, ci => ci.MapFrom(src => src.UserId))
                .ForMember(ce => ce.Tittle, ci => ci.MapFrom(src => src.Tittle))
                .ForMember(ce => ce.DateOfCreating, ci => ci.MapFrom(src => src.DateOfCreating.ToString("dd/MM/yyyy")));
        }
    }
}
