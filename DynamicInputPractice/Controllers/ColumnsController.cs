using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Logics;
using Microsoft.AspNetCore.Mvc;

namespace DynamicInputPractice.Controllers
{
    public class ColumnsController : Controller
    {
        private readonly IColumnLogic _columnLogic;

        public ColumnsController(IColumnLogic columnLogic)
        {
            _columnLogic = columnLogic;
        }


        public IActionResult Index()
        {
            var model = _columnLogic.Get();
            return View();
        }
    }
}