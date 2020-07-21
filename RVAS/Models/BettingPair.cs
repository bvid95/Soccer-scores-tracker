using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace RVAS.Models
{
    public class BettingPair
    {
        public int Id { get; set; }
        public Match Match { get; set; }

        public int BettingTipId { get; set; }
        public BettingTip BettingTip {get; set; }
    }
}