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

namespace RVAS.Controllers
{
    public class StandingsController : Controller
    {
        private ApplicationDbContext _context;

        public StandingsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Standings
        public async Task<ActionResult> StandingIndex()
        {

            var client = new RestClient("http://api.football-data.org/v2");
            client.UseNewtonsoftJson();
            var request = new RestRequest("competitions/2021/standings", DataFormat.Json).AddHeader("X-Auth-Token", "aaf2b68a9b6549509e80746c1430e846");

            var response = client.Get(request);

            var standing = JsonConvert.DeserializeObject<HeadStanding>(response.Content);
            int a = 2;

            return View(standing.Standings[a]);

        }

        

    }
}