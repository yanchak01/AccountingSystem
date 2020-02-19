using AccountingSystem.Services.Interfaces;
using AccountingSystem.ViewModels.EntitieViewModels;
using AutoMapper;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace AccountingSystem.Services.Classes
{
    public class JsonLoadServices : IJsonLoadServices
    {
        private string methodUrl = "https://jsonplaceholder.typicode.com/users/1/posts";
        private readonly IMapper _mapper;
        public JsonLoadServices(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<RecordsViewModel>> Load()
        {
            var records = await Parse(methodUrl);
            return _mapper.Map<IEnumerable<RecordJsonModel>, IEnumerable<RecordsViewModel>>(records);
        }

        private async Task<IEnumerable<RecordJsonModel>> Parse(string methodUrl)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(methodUrl);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            IEnumerable<RecordJsonModel> records = await Task.Run(()=>JsonConvert.DeserializeObject<IEnumerable<RecordJsonModel>>(response));

            return records;
        }


    }
}
