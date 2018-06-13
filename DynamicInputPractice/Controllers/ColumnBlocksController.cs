using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.ILogics;
using Microsoft.AspNetCore.Mvc;

namespace DynamicInputPractice.Controllers
{
    public class ColumnBlocksController : Controller
    {
        private readonly IColumnBlockLogic _logic;

        public ColumnBlocksController(IColumnBlockLogic logic)
        {
            _logic = logic;
        }

        public IActionResult Index()
        {
            var model = _logic.Get();
            return View(model);
        }
    }
}