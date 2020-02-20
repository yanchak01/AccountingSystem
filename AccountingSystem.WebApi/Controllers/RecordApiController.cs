using AccountingSystem.Services.Interfaces;
using AccountingSystem.ViewModels.EntitieViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace AccountingSystem.WebApi.Controllers
{
    [System.Web.Mvc.Route("[controller]/[action]")]
    public class RecordApiController : Controller
    {
        private readonly IJsonCreateServices _jsonCreateServices;
        private readonly IRecordServices _recordServices;
        public RecordApiController(IJsonCreateServices jsonCreateServices, IRecordServices recordServices)
        {
            _jsonCreateServices = jsonCreateServices;
            _recordServices = recordServices;
        }

        /// <summary>
        /// Return JSON just like a string
        /// </summary>
        /// <returns></returns>
        [System.Web.Mvc.Route("RecordApi/ GetJsonLikeString)")]
        [System.Web.Mvc.HttpGet]
        public async Task<string> GetJsonLikeString()
        {
            var json = await _recordServices.RecordsList();
            return await _jsonCreateServices.CreateJsonAll(json);
        }

        /// <summary>
        /// Return JSON with DateOfCreating in ticks
        /// </summary>
        /// <returns></returns>
        //Return JSON with DateOfCreating in ticks {dateofcreating = 1582152030323}
        [System.Web.Mvc.Route("RecordApi/Get)")]
        [System.Web.Mvc.HttpGet]
        public async Task<JsonResult> Get()
        {
            return Json(await _jsonCreateServices.CreateValidJson(await _recordServices.RecordsList()), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Return JSON with the slashes
        /// </summary>
        /// <returns></returns>
        //Return JSON with the slashes {\"Id\":29,\"UserId\":1,\"Tittle\":\"qui est esse\",\"DateOfCreating\":\"2020-02-20T00:40:30.323\"}
        [System.Web.Mvc.Route("RecordApi/GetSpecifyJson)")]
        [System.Web.Mvc.HttpGet]
        public async Task<JsonResult> GetSpecifyJson()
        {
            return Json(await _jsonCreateServices.CreateJsonAll(await _recordServices.RecordsList()), JsonRequestBehavior.AllowGet);
        }
    }
}