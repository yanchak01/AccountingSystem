using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingSystem.Services.Interfaces;
using AccountingSystem.ViewModels.EntitieViewModels;

namespace AccountingSystem.Services.Classes
{
    public class CounterServices : ICounterServices
    {
        public async Task<StatisticsViewModel> GetStatistic(IEnumerable<RecordsViewModel> records)
        {
           
            var dict = await Task.Run(()=>records.GroupBy(x => x.DateOfCreating.ToString("dd.MM.yyyy")).ToDictionary(g => g.Key, g => g.Count()));

            return new StatisticsViewModel { Statistic = dict};
        }
    }
}
