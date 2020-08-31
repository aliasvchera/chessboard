using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ChessBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace ChessBoard.Controllers
{
    public class TransitionController : Controller
    {
        private IChessBoardRepository repository;

        public TransitionController(IChessBoardRepository repository)
        {
            this.repository = repository;
        }

        //public ViewResult Map() => View(repository.Transitions);
        public ViewResult Map()
        {
            var transactionLines = from t in repository.Transitions
                       join r1 in repository.Regions on t.RegionName1 equals r1.Name
                       join r2 in repository.Regions on t.RegionName2 equals r2.Name
                       select new TransactionLine {
                           RegionName1 = t.RegionName1, X1 = r1.X, Y1 = r1.Y, 
                           RegionName2 = t.RegionName2, X2 = r2.X, Y2 = r2.Y
                       };
            var data = new TransactionModel { Regions = repository.Regions, TransactionLines = transactionLines };
            return View(data);
        }
    }
}
