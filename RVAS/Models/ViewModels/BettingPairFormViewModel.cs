using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RVAS.Models.ViewModels
{
    public class BettingPairFormViewModel
    {
        public List<BettingPair> BettingPairs { get; set; }
        public IEnumerable<BettingTip> BettingTips { get; set; }
    }
}