using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.ILogics;
using BLL.Logics;
using Microsoft.AspNetCore.Mvc;

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
            var model = _columnValueLogic.Get(id);
            return View();
        }
    }
}