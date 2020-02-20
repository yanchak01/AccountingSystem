using AccountingSystem.Services.Interfaces;
using AccountingSystem.ViewModels.EntitieViewModels;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public JsonCreateServices(IMapper mapper)
        {
            _mapper = mapper;
        }
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

        public async Task<IEnumerable<JsonViewModel>> CreateValidJson(IEnumerable<RecordsViewModel> records)
        {
            var json = await Task.Run(() => _mapper.Map<IEnumerable<RecordsViewModel>, IEnumerable<JsonViewModel>>(records));
            return json;
        }
    }
}
