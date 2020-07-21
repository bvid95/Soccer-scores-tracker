using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RVAS.Models
{
    public class HomeTeamAwayTeam
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("homeTeam")]
        public long? HomeTeam { get; set; }

        [JsonProperty("awayTeam")]
        public long? AwayTeam { get; set; }
    }
}