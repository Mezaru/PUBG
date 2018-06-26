using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PUBG.Models;
using PUBG.Models.ViewModels;
using static PUBG.Models.PUBGmodels;

namespace PUBG.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiCalls api;

        public HomeController(ApiCalls api)
        {
            this.api = api;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new HomeIndexVM { Regions = api.GetRegions() });
        }

        [HttpPost]
        public async Task<IActionResult> Index(HomeIndexVM model)
        {
            var player = await api.GetPlayerAsync(model.SelectedRegion, model.PlayerName);
            HttpContext.Session.SetString("Player", player);
            HttpContext.Session.SetString("Region", model.SelectedRegion);
            return RedirectToAction(nameof(PlayerDetail));
        }

        [HttpGet]
        public async Task<IActionResult> PlayerDetail()
        {
            var player = HttpContext.Session.GetString("Player");
            var region = HttpContext.Session.GetString("Region");
            var playerModel = JsonConvert.DeserializeObject<Player>(player);
            var match = await api.GetMatchInfo(playerModel, region);

            return View(new HomePlayerDetailVM { Player = playerModel, Matches = match, Seasons = await api.GetSeasonsAsync(region) });
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }

        public async Task<string> GetSeason(string season, string gameMode)
        {
            var playerId = JsonConvert.DeserializeObject<Player>(HttpContext.Session.GetString("Player")).Data.First().Id;
            var region = HttpContext.Session.GetString("Region");

            var result = await api.GetSeasonDataFromPlayer(playerId, region, season);

            return result;
        }
    }
}
