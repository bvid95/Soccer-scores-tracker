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
using Microsoft.Ajax.Utilities;

namespace RVAS.Controllers
{
    public class HeadStandingsController : Controller
    {
       
        private ApplicationDbContext _context;
        public HeadStandingsController()
        {

            _context = new ApplicationDbContext();
        }
        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }
        // GET: HeadStandings
        public async Task<ActionResult> HeadStandingIndex()
        {

            var client = new RestClient("http://api.football-data.org/v2");
            client.UseNewtonsoftJson();
            var request = new RestRequest("competitions/2021/standings", DataFormat.Json).AddHeader("X-Auth-Token", "aaf2b68a9b6549509e80746c1430e846");

            var response = client.Get(request);


            var headStanding = JsonConvert.DeserializeObject<HeadStanding>(response.Content);
            var date = DateTime.Now;
            var finaldate = date.AddYears(-1);


            Competition competition = headStanding.Competition;
            Season season = headStanding.Season;
            List<Standing> standing = headStanding.Standings;
            List<Table> tableAll = standing[0].Table;
            List<Table> tableHome = standing[1].Table;
            List<Table> tableAway = standing[2].Table;
            _context.HeadStandings.AddOrUpdate(headStanding);

            foreach (var s in headStanding.Standings)
            {
                foreach (var c in s.Table)
                {
                    _context.Entry(c.Team).State = EntityState.Detached;
                }

            }

            _context.Entry(competition).State = EntityState.Modified;
            _context.Entry(season).State = EntityState.Modified;
                        
            _context.SaveChanges();


            return View(headStanding);

        }
    }
}