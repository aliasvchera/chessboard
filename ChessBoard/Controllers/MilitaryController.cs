using ChessBoard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChessBoard.Controllers
{
    public class MilitaryController : Controller
    {
        private IChessBoardRepository repository;

        public MilitaryController(IChessBoardRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult TestMap()
        {
            var model = new MilitaryModel { 
                Armies = repository.Armies.Include(a => a.Units),
                Fortresses = repository.Fortresses.Include(a => a.Units)
            };
            return View(model);
        }

        //[HttpPost]
        public RedirectToActionResult Recrute(string militaryName)
        {
            repository.AddUnit(militaryName);
            return RedirectToAction("TestMap");
        }
    }
}
