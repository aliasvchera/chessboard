using ChessBoard.Models;
using ChessBoard.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly IChessBoardRepository repository;
        private readonly UserManager<User> userManager;

        public MilitaryController(IChessBoardRepository repository, UserManager<User> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }

        [Authorize(Roles = "player")]
        public async Task<IActionResult> Map()
        {
            User user = await userManager.GetUserAsync(User);
            string userName = user?.UserName;
            System.Console.WriteLine($"Current user: {userName}");

            var romans = repository.Factions.Where(f =>
                (f.FactionId.StartsWith(userName + "|") & f.Civilization == Civilization.PaxRomana)).Select(f => f.FactionId).ToList();
            var barbarians = repository.Factions.Where(f => 
                (f.FactionId.StartsWith(userName + "|") & f.Civilization == Civilization.PaxBarbarica)).Select(f => f.FactionId).ToList();

            IEnumerable<string> destinationRegions0;
            IEnumerable<string> destinationRegions1;
            if (MilitaryModel.selectedArmy is null)
            {
                destinationRegions0 = Enumerable.Empty<string>();
                destinationRegions1 = Enumerable.Empty<string>();
            }
            else
            {
                var army = repository.Armies.Where(a => a.MilitaryId == MilitaryModel.selectedArmy).FirstOrDefault();
                string regionId = army.RegionId;
                if (army.DestinationRegionId1 != null)
                {
                    destinationRegions0 = new List<string>() { army.DestinationRegionId1 };
                    if (army.DestinationRegionId2 != null)
                    {
                        destinationRegions1 = new List<string>() { army.DestinationRegionId2 };
                    }
                    else
                    {
                        destinationRegions1 = (from t in repository.Transitions
                                               where destinationRegions0.Contains(t.RegionId1)
                                                    && !destinationRegions0.Contains(t.RegionId2)
                                                    && t.PermittedForPlayer
                                               select t.RegionId2
                                              ).Union
                                             (from t in repository.Transitions
                                              where destinationRegions0.Contains(t.RegionId2)
                                                    && !destinationRegions0.Contains(t.RegionId1)
                                                    && t.PermittedForPlayer
                                              select t.RegionId1
                                             );
                    }                        
                }
                else
                {
                    destinationRegions0 = (from t in repository.Transitions
                                           where t.RegionId1 == regionId && t.PermittedForPlayer
                                           select t.RegionId2
                                          ).Union
                                         (from t in repository.Transitions
                                          where t.RegionId2 == regionId && t.PermittedForPlayer
                                          select t.RegionId1
                                         );
                    destinationRegions1 = Enumerable.Empty<string>();
                }
                
            }
            var model = new MilitaryModel(userName + "|MM_per_Thracias") {
                Regions = repository.Regions.Where(r => r.RegionId.StartsWith(userName + "|"))
                    .Include(region => region.Armies).ThenInclude(a => a.Units)
                    .Include(region => region.Fortresses).ThenInclude(f => f.Units),
                Factions = repository.Factions.Where(f => f.FactionId.StartsWith(userName + "|"))
                    .Include(faction => faction.Militaries),
                DestinationRegions0 = destinationRegions0,
                DestinationRegions1 = destinationRegions1,
                Romans = romans,
                Barbarians = barbarians
            };

            return View(model);
        }

        //[HttpPost]
        [Authorize(Roles = "player")]
        public RedirectToActionResult Recrute(string militaryName)
        {
            repository.AddUnit(militaryName);
            return RedirectToAction("Map");
        }

        [Authorize(Roles = "player")]
        public RedirectToActionResult SelectArmy(string selectedArmy)
        {
            System.Console.WriteLine($"Selected army: {selectedArmy}");
            if (MilitaryModel.selectedArmy != selectedArmy)
            {
                MilitaryModel.selectedArmy = selectedArmy;
            }
            else
            {
                MilitaryModel.selectedArmy = null;
            }
            return RedirectToAction("Map");
        }

        [Authorize(Roles = "player")]
        public RedirectToActionResult SelectDestination(string regionId, byte step)
        {
            repository.UpdateDestination(MilitaryModel.selectedArmy, regionId, step);
            return RedirectToAction("Map");
        }

        [Authorize(Roles = "player")]
        public RedirectToActionResult NextTurn()
        {
            repository.ProcessTurn();
            return RedirectToAction("Map");
        }
    }
}
