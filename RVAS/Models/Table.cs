using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RVAS.Models
{
    public class Table
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("position")]
        public long Position { get; set; }

        [JsonProperty("team")]
        public Team Team { get; set; }

        [JsonProperty("playedGames")]
        public long PlayedGames { get; set; }

        [JsonProperty("won")]
        public long Won { get; set; }

        [JsonProperty("draw")]
        public long Draw { get; set; }

        [JsonProperty("lost")]
        public long Lost { get; set; }

        [JsonProperty("points")]
        public long Points { get; set; }

        [JsonProperty("goalsFor")]
        public long GoalsFor { get; set; }

        [JsonProperty("goalsAgainst")]
        public long GoalsAgainst { get; set; }

        [JsonProperty("goalDifference")]
        public long GoalDifference { get; set; }
    }
}