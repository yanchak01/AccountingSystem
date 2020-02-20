using AccountingSystem.ViewModels.EntitieViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystem.Services.Interfaces
{
    public interface ICounterServices
    {
        Task<StatisticsViewModel> GetStatistic(IEnumerable<RecordsViewModel> records);
    }
}
