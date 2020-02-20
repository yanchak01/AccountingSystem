using AccountingSystem.ViewModels.EntitieViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AccountingSystem.Services.Interfaces
{
    public interface IJsonCreateServices
    {
        Task<string> CreateJsonAll(IEnumerable<RecordsViewModel> records);
        Task<IEnumerable<JsonViewModel>> CreateValidJson(IEnumerable<RecordsViewModel> records);
        Task<string> CreateJsonId(RecordsViewModel record);
    }
}
