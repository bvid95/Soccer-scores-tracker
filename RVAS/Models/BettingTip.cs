using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RVAS.Models
{
    public class BettingTip
    {
        public int id { get; set; }
        public string Tip { get; set; }
        public ICollection<BettingPair> BettingPairs { get; set; }
    }
}