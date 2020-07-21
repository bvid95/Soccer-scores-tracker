using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations.Schema;


namespace RVAS.Models
{
    public class Match
    {
        public Match()
        {

            this.Referees = new HashSet<Referee>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("competition")]
        public Competition Competition { get; set; }

        [JsonProperty("season")]
        public Season Season { get; set; }

        [JsonProperty("utcDate")]
        public DateTime? UtcDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("venue")]
        public string Venue { get; set; }

        [JsonProperty("matchday")]
        public long Matchday { get; set; }

        [JsonProperty("stage")]
        public string Stage { get; set; }

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTime? LastUpdated { get; set; }

        [JsonProperty("score")]
        public Score Score { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [JsonProperty("homeTeam")]
        public Team HomeTeam { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [JsonProperty("awayTeam")]
        public Team AwayTeam { get; set; }

        [JsonProperty("referees")]
        public virtual ICollection<Referee> Referees { get; set; }
    }
    
   
}
