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

namespace RVAS.Controllers
{
    public class CompetitionsController : Controller
    {
        // GET: Competitions
        [System.Web.Mvc.Authorize(Roles = RoleName.Admin)]
        public async Task<ActionResult> Index()
        {

            var client = new RestClient("http://api.football-data.org/v2");
            client.UseNewtonsoftJson();
            var request = new RestRequest("competitions/2021", DataFormat.Json).AddHeader("X-Auth-Token", "aaf2b68a9b6549509e80746c1430e846");

            var response = client.Get(request);

            var competition = JsonConvert.DeserializeObject<Competition>(response.Content);

            
            return View(competition);

        }
    }
}