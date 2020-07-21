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
using PagedList;

namespace RVAS.Controllers
{
    public class MatchesController : Controller
    {
        private ApplicationDbContext _context;

        public MatchesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Matches
        [System.Web.Mvc.Authorize(Roles = RoleName.Admin)]
        public async Task<ActionResult> MatchIndex()
        {

            var client = new RestClient("http://api.football-data.org/v2");
            client.UseNewtonsoftJson();
            var request = new RestRequest("matches/264640", DataFormat.Json).AddHeader("X-Auth-Token", "aaf2b68a9b6549509e80746c1430e846");

            var response = client.Get(request);

            var match = JsonConvert.DeserializeObject<Match>(response.Content);

            return View(match);

        }

        public ActionResult AllMatches(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            var matches = _context.Matches.ToList();
            var teams = _context.Teams.ToList();
            var score = _context.Scores.ToList();
            var homeTeamAwayTeam = _context.HomeTeamAwayTeams.ToList();

            var sorteda = matches.OrderBy(ma => ma.UtcDate);

            var viewModel = new MatchScoreViewModel()
            {
                Matches = sorteda.ToPagedList(pageNumber, pageSize),
                Scores = score,
                HomeTeamAwayTeams = homeTeamAwayTeam
            };
            ViewBag.CurrentSort = sortOrder;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                var sorted = matches.Where(s => s.Status.ToLower().Contains(searchString.ToLower()));
                var sortedViewModel = new MatchScoreViewModel()
                {
                    Matches = sorted.ToPagedList(pageNumber, pageSize),
                    Scores = score,
                    HomeTeamAwayTeams = homeTeamAwayTeam
                };
                return View("AllMatches", sortedViewModel);

            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "date" : "";
            if (sortOrder == "name")
            {
                var sorted = matches.OrderByDescending(a => a.Status);
                var sortedViewModel = new MatchScoreViewModel()
                {
                    Matches = sorted.ToPagedList(pageNumber, pageSize),
                    Scores = score,
                    HomeTeamAwayTeams = homeTeamAwayTeam
                };
                return View("AllMatches", sortedViewModel);
            }
            else if (sortOrder == "date")
            {
                var sorted = matches.OrderByDescending(a => a.UtcDate);

                var sortedViewModel = new MatchScoreViewModel()
                {
                    Matches = sorted.ToPagedList(pageNumber, pageSize),
                    Scores = score,
                    HomeTeamAwayTeams = homeTeamAwayTeam
                };
                return View("AllMatches", sortedViewModel);
            }

            return View(viewModel);
        }
    }
}