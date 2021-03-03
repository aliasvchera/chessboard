using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ChessBoard.Models;
using ChessBoard.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ChessBoard.Controllers
{
    public class TransitionController : Controller
    {
        private readonly IChessBoardRepository repository;

        public TransitionController(IChessBoardRepository repository)
        {
            this.repository = repository;
        }

        [Authorize(Roles = "admin")]
        public ViewResult TestMap()
        {
            var transactionLines = from t in repository.Transitions
                       join r1 in repository.Regions on t.RegionId1 equals r1.RegionId
                       join r2 in repository.Regions on t.RegionId2 equals r2.RegionId
                       select new TransitionLine {
                           RegionName1 = t.RegionId1, X1 = r1.X, Y1 = r1.Y, 
                           RegionName2 = t.RegionId2, X2 = r2.X, Y2 = r2.Y,
                           PermittedForPlayer = t.PermittedForPlayer
                       };
            var data = new TransitionModel { Regions = repository.Regions, TransitionLines = transactionLines };
            return View(data);
        }
    }
}
