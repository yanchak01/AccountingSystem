using AccountingSystem.Services.Interfaces;
using AccountingSystem.ViewModels.EntitieViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace AccountingSystem.Controllers
{
    public class RecordController : Controller
    {
        private readonly IRecordServices _recordServices;

        public RecordController(IRecordServices recordServices)
        {
            _recordServices = recordServices;
        }
        // GET: Record
        public async Task<ActionResult> Index()
        {
            var records = await _recordServices.RecordsList();
            return View(records);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(RecordsViewModel record)
        {
            await _recordServices.CreateRecord(record);
            return RedirectToAction("Index");   
        }
    }
}