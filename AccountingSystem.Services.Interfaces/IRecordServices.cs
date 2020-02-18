using AccountingSystem.Domain.Core;
using AccountingSystem.ViewModels.EntitieViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountingSystem.Services.Interfaces
{
    public interface IRecordServices
    {
        Task CreateRecord(RecordsViewModel record);
        Task<IEnumerable<RecordsViewModel>> RecordsList(); 
    }
}
