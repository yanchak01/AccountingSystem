using AccountingSystem.Services.Interfaces;
using AccountingSystem.ViewModels.EntitieViewModels;
using AccountingSystem.ViewModels.EntitieViewModels.Validators;
using FluentValidation.Results;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AccountingSystem.Controllers
{
    public class RecordController : Controller
    {
        private readonly IRecordServices _recordServices;
        private readonly IJsonLoadServices _jsonLoadServices;
        private readonly ICounterServices _counterService;

        public RecordController(IRecordServices recordServices, IJsonLoadServices jsonLoadServices, ICounterServices counterService)
        {
            _recordServices = recordServices;
            _jsonLoadServices = jsonLoadServices;
            _counterService = counterService;
        }
       
        public async Task<ActionResult> Index()
        {
            var records = await _recordServices.RecordListByDate();
            return View(records);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(RecordsViewModel record)
        {
            RecordViewModelValidator validations = new RecordViewModelValidator();
            ValidationResult result = await validations.ValidateAsync(record);
            if (result.IsValid)
            {
                await _recordServices.CreateRecord(record);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var failure in result.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
            }
            return View(record);
               
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int Id)
        {
            return View(await _recordServices.GetRecordById(Id));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RecordsViewModel record)
        {
            RecordViewModelValidator validations = new RecordViewModelValidator();
            ValidationResult result = await validations.ValidateAsync(record);
            if (result.IsValid)
            {
                await _recordServices.UpdateRecord(record);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var failure in result.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
            }
            return View(record);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int Id, string confirmButton)
        {
            var record = await _recordServices.GetRecordById(Id);
            if (record == null)
                return View("Not Found");
            else
            {
                 await _recordServices.Delete(Id);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int Id)
        {
            var record = await _recordServices.GetRecordById(Id);
            if (record == null)
                return View("Not Found");
            else
            return View(record);
        }

        
        public async Task<ActionResult> Load()
        {
            await _recordServices.CreateManyRecords(await _jsonLoadServices.Load());
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> StatisticsPage()
        {
            var records = await _recordServices.RecordListByDate();
            var res = await _counterService.GetStatistic(records);
            ViewBag.NUM = res.Statistic.Values;
            ViewBag.DATE = res.Statistic.Keys;
            return View(res);
        }  
    }
}