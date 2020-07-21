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
using RVAS.Models.ViewModels;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.Security.Cryptography;
using System.Data.Entity.Migrations;
using System.Data.Entity;

namespace RVAS.Controllers
{

    public class HeadMatchListByCompetitionsController : Controller
    {
        private ApplicationDbContext _context;
        private ApplicationDbContext _context2;
        public HeadMatchListByCompetitionsController()
        {

            _context = new ApplicationDbContext();
            _context2 = new ApplicationDbContext();

        }
        [System.Web.Mvc.Authorize(Roles = RoleName.Admin)]
        public async Task<ActionResult> HeadMatchListByCompetitions()
        {

            var client = new RestClient("http://api.football-data.org/v2");
            client.UseNewtonsoftJson();
            var request = new RestRequest("competitions/2021/matches?dateFrom=2020-06-27&dateTo=2020-07-01", DataFormat.Json).AddHeader("X-Auth-Token", "aaf2b68a9b6549509e80746c1430e846");

            var response = client.Get(request);


            var headMatchListByCompetition = JsonConvert.DeserializeObject<HeadMatchListByCompetition>(response.Content);

            var date = DateTime.Now;
            var finaldate = date.AddYears(-2);

            Competition competition = headMatchListByCompetition.Competition;

            foreach (Match match in headMatchListByCompetition.Matches)
            {

                var hTeamInDb = _context.Teams.SingleOrDefault(x => x.Id == match.HomeTeam.Id);
                var aTeamInDb = _context.Teams.SingleOrDefault(x => x.Id == match.AwayTeam.Id);
                match.HomeTeam = hTeamInDb;
                match.AwayTeam = aTeamInDb;
                

                _context.Entry(match.HomeTeam).State = EntityState.Modified;
                _context.Entry(match.AwayTeam).State = EntityState.Modified;


                _context.Set<Match>().AddOrUpdate(match);
                _context.Teams.AddOrUpdate(hTeamInDb);
                _context.Teams.AddOrUpdate(aTeamInDb);


                _context.Set<HomeTeamAwayTeam>().AddOrUpdate(match.Score.FullTime);
                _context.Set<HomeTeamAwayTeam>().AddOrUpdate(match.Score.ExtraTime);
                _context.Set<HomeTeamAwayTeam>().AddOrUpdate(match.Score.Penalties);
                _context.Set<HomeTeamAwayTeam>().AddOrUpdate(match.Score.HalfTime);

                _context.Entry(match.Season).State = EntityState.Detached;

                match.HomeTeam.LastUpdated = finaldate;
                match.AwayTeam.LastUpdated = finaldate;


                _context.Entry(match.HomeTeam).State = EntityState.Modified;
                _context.Entry(match.AwayTeam).State = EntityState.Modified;

            }


            
            _context.Competitions.Attach(competition);
            _context.SaveChanges();

            return View(headMatchListByCompetition);

        }
    }
}