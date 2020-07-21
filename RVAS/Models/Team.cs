using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations.Schema;


namespace RVAS.Models
{
    public partial class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("tla")]
        public string Tla { get; set; }

        [JsonProperty("crestUrl")]
        public string CrestUrl { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("founded")]
        public int Founded { get; set; }

        [JsonProperty("clubColors")]
        public string ClubColors { get; set; }

        [JsonProperty("venue")]
        public string Venue { get; set; }

        [JsonProperty("squad")]
        public List<Player> Squad { get; set; }

        [JsonProperty("lastupdated")]
        public DateTime LastUpdated { get; set; }
    }
}