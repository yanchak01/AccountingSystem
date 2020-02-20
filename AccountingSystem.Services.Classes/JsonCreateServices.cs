using AccountingSystem.Services.Interfaces;
using AccountingSystem.ViewModels.EntitieViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AccountingSystem.Services.Classes
{
    public class JsonCreateServices : IJsonCreateServices
    {
        public async Task<string> CreateJsonAll(IEnumerable<RecordsViewModel> records)
        {
            string jsonResult = await Task.Run(()=>JsonConvert.SerializeObject(records));
            return jsonResult;
        }

        public async Task<string> CreateJsonId(RecordsViewModel record)
        {
            
            string jsonResult = await Task.Run(() => JsonConvert.SerializeObject(record));
            return jsonResult;
        }

        public async Task<JsonResult> CreateValidJson(IEnumerable<RecordsViewModel> records)
        {
            return new JsonResult() { Data = records, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
