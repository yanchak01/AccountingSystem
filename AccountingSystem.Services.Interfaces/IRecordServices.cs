using AccountingSystem.Domain.Core;
using AccountingSystem.ViewModels.EntitieViewModels;
using System.Threading.Tasks;

namespace AccountingSystem.Services.Interfaces
{
    public interface IRecordServices
    {
        Task CreateRecord(RecordsViewModel record);
    }
}
