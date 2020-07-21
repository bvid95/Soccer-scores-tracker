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
    public class HeadMatchController : Controller
    {
        private ApplicationDbContext _context;
        public HeadMatchController()
        {

            _context = new ApplicationDbContext();
        }

        [System.Web.Mvc.Authorize(Roles = RoleName.Admin)]
        public async Task<ActionResult> HeadMatchIndex()
        {
            var date = DateTime.Now;
            var finaldate = date.AddYears(-2);

            var client = new RestClient("http://api.football-data.org/v2");
            client.UseNewtonsoftJson();
            var request = new RestRequest("matches/264670", DataFormat.Json).AddHeader("X-Auth-Token", "aaf2b68a9b6549509e80746c1430e846");

            var response = client.Get(request);

            var headmatch = JsonConvert.DeserializeObject<HeadMatch>(response.Content);

            
            headmatch.Id = Convert.ToInt32(headmatch.Match.Id);
            
            _context.Set<Match>().AddOrUpdate(headmatch.Match);


            headmatch.Match.HomeTeam.LastUpdated = finaldate;
            headmatch.Match.AwayTeam.LastUpdated = finaldate;
            _context.Entry(headmatch.Match.HomeTeam).State = EntityState.Modified;
            _context.Entry(headmatch.Match.AwayTeam).State = EntityState.Modified;
            _context.Set<HomeTeamAwayTeam>().AddOrUpdate(headmatch.Match.Score.FullTime);
            _context.Set<HomeTeamAwayTeam>().AddOrUpdate(headmatch.Match.Score.ExtraTime);
            _context.Set<HomeTeamAwayTeam>().AddOrUpdate(headmatch.Match.Score.Penalties);
            _context.Set<HomeTeamAwayTeam>().AddOrUpdate(headmatch.Match.Score.HalfTime);
            


            _context.Competitions.Attach(headmatch.Match.Competition);
            _context.Entry(headmatch.Match.Season).State = EntityState.Detached;
            _context.SaveChanges();
         

            return View(headmatch);

        }

        public ActionResult AllHeadMatches()
        {
            var headMatches = _context.HeadMatches.ToList();
            return View(headMatches);
        }
    }
}