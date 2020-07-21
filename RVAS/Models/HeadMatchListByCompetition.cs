using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RVAS.Models
{
    public class HeadMatchListByCompetition
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("competition")]
        public Competition Competition { get; set; }

        [JsonProperty("matches")]
        public List<Match> Matches { get; set; }

    }
}