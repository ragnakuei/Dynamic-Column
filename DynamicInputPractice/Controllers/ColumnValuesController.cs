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
        public IActionResult ReadyToAnswer()
        {
            var vModel = _columnValueLogic.Get();
            return View(vModel);
        }


        [HttpGet]
        public IActionResult AnswerQuestions(Guid id)
        {
            var vModel = _columnValueLogic.Get();
            return View(vModel);
        }

        [HttpPost]
        public IActionResult AnswerQuestions(List<ColumnBlockDTO> vModel)
        {
            if ( ModelState.IsValid == false )
                return View(vModel);

            _columnValueLogic.UpdateValue(vModel);
            return RedirectToAction("ShowAnswers");
        }
        
        [HttpGet]
        public IActionResult ShowAnswers()
        {
            var vModel = _columnValueLogic.Get();
            return View(vModel);
        }
    }
}