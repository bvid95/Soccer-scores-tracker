using RVAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RVAS.Controllers.Api
{
    public class RefereesController : ApiController
    {
        private ApplicationDbContext _context;

        public RefereesController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Referee> GetReferees()
        {
            return _context.Referees.ToList();
        }
        [System.Web.Mvc.Authorize(Roles = RoleName.Admin)]
        public Referee GetReferee(int id)
        {
            var referee = _context.Referees.SingleOrDefault(r => r.Id == id);

            if (referee == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return referee;
        }

        [HttpPost]
        [System.Web.Mvc.Authorize(Roles = RoleName.Admin)]
        public Referee CreateReferee (Referee referee)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Referees.Add(referee);
            _context.SaveChanges();

            return referee;
            
        }

        [HttpPut]
        [System.Web.Mvc.Authorize(Roles = RoleName.Admin)]
        public void UpdateReferee(int id, Referee referee)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var refereeInDb = _context.Referees.SingleOrDefault(r => r.Id == id);

            if (refereeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            refereeInDb = referee;

            _context.SaveChanges();
        }
        [System.Web.Mvc.Authorize(Roles = RoleName.Admin)]
        public void DeleteReferee(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var refereeInDb = _context.Referees.SingleOrDefault(r => r.Id == id);

            if (refereeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Referees.Remove(refereeInDb);
            _context.SaveChanges();
        }



   
    }
}
