using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RVAS.Models
{
    public class Score
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("winner")]
        public string Winner { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("fullTime")]
        public HomeTeamAwayTeam FullTime { get; set; }

        [JsonProperty("halfTime")]
        public HomeTeamAwayTeam HalfTime { get; set; }

        [JsonProperty("extraTime")]
        public HomeTeamAwayTeam ExtraTime { get; set; }

        [JsonProperty("penalties")]
        public HomeTeamAwayTeam Penalties { get; set; }
    }
}