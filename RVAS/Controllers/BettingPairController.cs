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
using System.Data.Entity;
using RVAS.Models.ViewModels;

namespace RVAS.Controllers
{
    public class BettingPairController : Controller
    {
        private ApplicationDbContext _context;
        public BettingPairController()
        {

            _context = new ApplicationDbContext();
        }
        
        // GET: BettingPair
        public ActionResult Index()
        {

            var matches = _context.Matches.Select(a => new
            {
                MatchId = a.Id,
                Name = a.HomeTeam.Name.ToString() + "--" + a.AwayTeam.Name.ToString()
            }).ToList();
            var viewModel = new BettingPairViewModel
            {
                
                Matches = new MultiSelectList(matches, "MatchId", "Name"),

            };

            return View(viewModel);
        }
        public ActionResult Create(int[] MatchId)
        {
            List<BettingPair> bettingPairs = new List<BettingPair>();
            var teams = _context.Teams.ToList();
            List<Match> matches = new List<Match>();
            var m = new BettingPair();           

            for(int i=0; i<MatchId.Length; i++)
            {
                int id = MatchId[i];
                var match = _context.Matches.SingleOrDefault(x => x.Id == id);
                matches.Add(match);
                m.Match = match;                
            }

            foreach (var r in matches)
            {
                var bp = new BettingPair();
                bp.Match = r;
                bettingPairs.Add(bp);
            }
            var bettingTip = _context.BettingTips.ToList();
                var viewModel = new BettingPairFormViewModel
            {
                BettingPairs = bettingPairs,
                BettingTips = bettingTip
            };


            return View(viewModel);
        }
        public ActionResult Save(int[] Id)
        {
            var bettingTicket = new BettingTicket();
            //bettingTicket.BettingPair = Id;

            return RedirectToAction("Index");
        }
    }
}