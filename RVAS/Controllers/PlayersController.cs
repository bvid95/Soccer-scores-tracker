using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using RVAS.Models;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers.NewtonsoftJson;
using RVAS.Controllers.Api;
using System.Data.Entity.Migrations;
using System.Threading;
using System.Web.Security;

namespace RVAS.Controllers
{
    public class PlayersController : Controller
    {
        private ApplicationDbContext _context;

        public PlayersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public async Task<ActionResult> Index()
        {

            var client = new RestClient("http://api.football-data.org/v2");
            client.UseNewtonsoftJson();
            var request = new RestRequest("players/67", DataFormat.Json).AddHeader("X-Auth-Token", "aaf2b68a9b6549509e80746c1430e846");

            var response = await client.ExecuteAsync(request);

            var player = JsonConvert.DeserializeObject<Player>(response.Content);


            return View(player);

        }
        public ActionResult AllPlayers()
        {
            var players = _context.Players.ToList();
            if (User.IsInRole(RoleName.Admin))
            {
            return View(players);
            }
            return View("AllPLayersUnaothorized", players);
        }
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        [System.Web.Mvc.Authorize(Roles = RoleName.Admin)]
        public ActionResult Create(Player player)
        {
            _context.Players.AddOrUpdate(player);
            _context.SaveChanges();

            return RedirectToAction("AllPlayers");
        }

        [System.Web.Mvc.Authorize(Roles = RoleName.Admin)]
        public ActionResult New()
        {
           
            return View();
        }

        [System.Web.Mvc.Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit (int id)
        {
            var player = _context.Players.SingleOrDefault(p => p.Id == id);
            if (player == null)
                return HttpNotFound();

            return View("New", player);

        }
        [System.Web.Mvc.Authorize(Roles = RoleName.Admin)]
        public ActionResult Delete(int id)
        {
            var player = _context.Players.SingleOrDefault(p => p.Id == id);
            if (player == null)
                return HttpNotFound();
            _context.Players.Remove(player);
            _context.SaveChanges();


            return RedirectToAction("AllPlayers");

        }


    }
}
