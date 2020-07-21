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
    public class TablesController : Controller
    {
        private ApplicationDbContext _context;

        public TablesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Tables
        public ActionResult Index()
        {
            var table = _context.Tables;
            return View();
        }
    }
}