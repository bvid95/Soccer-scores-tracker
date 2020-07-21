using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RVAS.Models.ViewModels
{
    public class StandingsTableViewModel
    {
        public HeadStanding HeadStandings { get; set; }
        public List<Standing> Standings { get; set; }

        public List<Table> Tables { get; set; }

    }
}