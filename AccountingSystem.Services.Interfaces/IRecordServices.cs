using AccountingSystem.Domain.Core;
using AccountingSystem.ViewModels.EntitieViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountingSystem.Services.Interfaces
{
    public interface IRecordServices
    {
        Task CreateRecord(RecordsViewModel record);
        Task UpdateRecord(RecordsViewModel record);
        Task<RecordsViewModel> GetRecordById(int id);
        Task<IEnumerable<RecordsViewModel>> RecordsList();
        Task<IEnumerable<RecordsViewModel>> RecordListByDate();
        Task CreateManyRecords(IEnumerable<RecordsViewModel> records);
        Task Delete(int Id);
    }
}
