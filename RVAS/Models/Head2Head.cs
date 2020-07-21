using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RVAS.Models
{
    public class Head2Head
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("numberOfMatches")]
        public long NumberOfMatches { get; set; }

        [JsonProperty("totalGoals")]
        public long TotalGoals { get; set; }

        [JsonProperty("homeTeam")]
        public Team HomeTeam { get; set; }

        [JsonProperty("awayTeam")]
        public Team AwayTeam { get; set; }
    }
}