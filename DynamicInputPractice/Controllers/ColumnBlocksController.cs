using System;
using System.Collections.Generic;
using BLL.ILogics;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.DTOs;

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

        [HttpGet]
        public IActionResult Create()
        {
            var vModel = new ColumnBlockDTO();
            vModel.ColumnDTOs = new List<ColumnDTO>();
            vModel.ColumnDTOs.Add(new ColumnDTO());
            return View(vModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ColumnBlockDTO vModel)
        {
            if ( ModelState.IsValid )
            {
                _logic.Add(vModel);
                return RedirectToAction("Index");
            }

            return View(vModel);
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var vModel = _logic.Get(id);
            return View(vModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(Guid id)
        {
            _logic.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
