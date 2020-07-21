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
using System.EnterpriseServices;
using System.IO;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Web.UI.WebControls.Expressions;
using System.Data.Entity.Core.Common.CommandTrees;

namespace RVAS.Controllers
{
    public class TeamsController : Controller
    {
        private ApplicationDbContext _context;
        public TeamsController()
        {

            _context = new ApplicationDbContext();
        }
        public async Task<ActionResult> Index()
        {


            var client = new RestClient("http://api.football-data.org/v2");
            client.UseNewtonsoftJson();
            var request = new RestRequest("teams/1044", DataFormat.Json).AddHeader("X-Auth-Token", "aaf2b68a9b6549509e80746c1430e846");

            var response = client.Get(request);           
            

            var team = JsonConvert.DeserializeObject<Team>(response.Content);

            
            _context.Teams.AddOrUpdate(team);
            _context.SaveChanges();

            return View(team);

        }
        public ActionResult AllTeams()
        {
            var teams = _context.Teams.ToList();
            if (User.IsInRole(RoleName.Admin))
            {
                return View(teams);
            }
            return View("AllTeamsUnaothorized", teams);
        }
        [System.Web.Mvc.Authorize(Roles = RoleName.Admin)]
        public ActionResult Create(Team team)
        {
            var now = DateTime.Now;
            team.LastUpdated = now;
            _context.Teams.AddOrUpdate(team);
            _context.SaveChanges();

            return RedirectToAction("AllTeams");
        }
        [System.Web.Mvc.Authorize(Roles = RoleName.Admin)]
        public ActionResult New()
        {

            return View();
        }
        [System.Web.Mvc.Authorize(Roles = RoleName.Admin)]
        public ActionResult Delete(int id)
        {
            var team = _context.Teams.SingleOrDefault(p => p.Id == id);
            if (team == null)
                return HttpNotFound();
            _context.Teams.Remove(team);
            _context.SaveChanges();


            return RedirectToAction("AllTeams");

        }
        [System.Web.Mvc.Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int id)
        {
            var team = _context.Teams.SingleOrDefault(p => p.Id == id);
            if (team == null)
                return HttpNotFound();

            return View("New", team);

        }

    }
}
