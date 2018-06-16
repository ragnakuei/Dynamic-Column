using System;
using System.Collections.Generic;
using BLL.ILogics;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.DTOs;

namespace DynamicInputPractice.Controllers
{
    public class ColumnValuesController : Controller
    {
        private readonly IColumnBlockLogic _columnValueLogic;

        public ColumnValuesController(IColumnBlockLogic columnValueLogic)
        {
            _columnValueLogic=columnValueLogic;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vModel = _columnValueLogic.Get();
            return View(vModel);
        }


        [HttpGet]
        public IActionResult Create(Guid id)
        {
            var vModel = _columnValueLogic.Get();
            return View(vModel);
        }

        [HttpPost]
        public IActionResult Create(List<ColumnBlockDTO> vModel)
        {
            if ( ModelState.IsValid == false )
                return View(vModel);

            _columnValueLogic.UpdateValue(vModel);
            return RedirectToAction("Create");
        }
    }
}