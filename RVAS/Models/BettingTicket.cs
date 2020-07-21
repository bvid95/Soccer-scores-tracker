using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RVAS.Models
{
    public class BettingTicket
    {
        public int Id { get; set; }
        public List<BettingPair> BettingPair { get; set; }
        public ApplicationUser User { get; set; }

    }
}