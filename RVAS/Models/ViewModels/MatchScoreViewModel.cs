using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;


namespace RVAS.Models.ViewModels
{
    public class MatchScoreViewModel
    {
        public IPagedList<Match> Matches { get; set; }
        public IEnumerable<Score> Scores { get; set; }
        public IEnumerable<HomeTeamAwayTeam> HomeTeamAwayTeams { get; set; }
    }
}