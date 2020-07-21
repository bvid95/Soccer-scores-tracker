using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Mvc;
using RVAS.Models;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using RVAS.Controllers.Api;

namespace RVAS.Controllers
{
   
    public class RefereeController : Controller
    {

        private ApplicationDbContext _context;
        public RefereeController()
        {

            _context = new ApplicationDbContext();
        }

        // GET: Referees
        public ActionResult Index()
        {
            //var client = new RestClient("https://localhost:44356/");
            //client.UseNewtonsoftJson();
            //var request = new RestRequest("Api/Referees", DataFormat.Json);

            //var response = client.Get(request);
            //var referees = JsonConvert.DeserializeObject<List<Referee>>(response.Content);
            //return View(referees);
            var referees = _context.Referees.ToList();
            if (User.IsInRole(RoleName.Admin))
            {
                return View(referees);
            }

            return View("IndexUnaothorized",referees);

        }

        [System.Web.Mvc.Authorize(Roles = RoleName.Admin)]
        public ActionResult New()
        {

            return View();
        }
    }
}