﻿using AccountingSystem.Services.Interfaces;
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
        private readonly IJsonLoadServices _jsonLoadServices;

        public RecordController(IRecordServices recordServices, IJsonLoadServices jsonLoadServices)
        {
            _recordServices = recordServices;
            _jsonLoadServices = jsonLoadServices;
        }
        // GET: Record
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
             await _recordServices.CreateRecord(record);
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int Id)
        {
            return View(await _recordServices.GetRecordById(Id));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RecordsViewModel record)
        {
            await _recordServices.UpdateRecord(record);
            return RedirectToAction("Index");
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
            //var arr = await _jsonLoadServices.Load();
            await _recordServices.CreateManyRecords(await _jsonLoadServices.Load());
            return RedirectToAction("Index");
        }
    }
}