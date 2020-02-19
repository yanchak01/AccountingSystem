using AccountingSystem.Domain.Core;
using AccountingSystem.Domain.Interfaces;
using AccountingSystem.Services.Interfaces;
using AccountingSystem.ViewModels.EntitieViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
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

        public async Task CreateManyRecords(IEnumerable<RecordsViewModel> records)
        {
            foreach (var item in records)
            {
                await _recordRepository.Create(_mapper.Map<RecordsViewModel, Record>(item));
            }
            await _recordRepository.Save();
        }

        public async Task CreateRecord(RecordsViewModel record)
        {
            var entity = _mapper.Map<RecordsViewModel, Record>(record);
            await _recordRepository.Create(entity);
            await _recordRepository.Save();
        }

        public async Task Delete(int Id)
        {
            var record = await  _recordRepository.GetRecord(Id);
            await Task.Run(()=>_recordRepository.Delete(record));
            await _recordRepository.Save();
        }

        public async Task<RecordsViewModel> GetRecordById(int id)
        {
            return _mapper.Map<Record,RecordsViewModel>(await _recordRepository.GetRecord(id));
        }

        public async Task<IEnumerable<RecordsViewModel>> RecordListByDate()
        {
            var records = await _recordRepository.GetRecordList();
            var sortedRecords = records.OrderBy(x => x.DateOfCreating.TimeOfDay)
                .ThenBy(x => x.DateOfCreating.Date)
                .ThenBy(x => x.DateOfCreating.Year).Reverse();
            return _mapper.Map<IEnumerable<Record>, IEnumerable<RecordsViewModel>>(sortedRecords);
        }

        public async Task<IEnumerable<RecordsViewModel>> RecordsList()
        {
            var records = await _recordRepository.GetRecordList();
            return _mapper.Map<IEnumerable<Record>, IEnumerable<RecordsViewModel>>(records);
        }

        public async Task UpdateRecord(RecordsViewModel record)
        {
           var newRecord = _mapper.Map<RecordsViewModel,Record>(record);
            _recordRepository.Update(newRecord);
            await _recordRepository.Save();
        }
    }
}
