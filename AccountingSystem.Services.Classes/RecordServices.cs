using AccountingSystem.Domain.Core;
using AccountingSystem.Domain.Interfaces;
using AccountingSystem.Services.Interfaces;
using AccountingSystem.ViewModels.EntitieViewModels;
using AutoMapper;
using System.Threading.Tasks;

namespace AccountingSystem.Services.Classes
{
    public class RecordServices : IRecordServices
    {
        private readonly IRecordRepository _recordRepository;
        private readonly IMapper _mapper;

        public RecordServices(IRecordRepository recordRepository,IMapper mapper)
        {
            _recordRepository = recordRepository;
            _mapper = mapper;
        }
        public async Task CreateRecord(RecordsViewModel record)
        {
            var entity = _mapper.Map<RecordsViewModel, Record>(record);
            await _recordRepository.Create(entity);
            await _recordRepository.Save();
        }
    }
}
