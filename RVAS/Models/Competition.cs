using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace RVAS.Models
{
    public class Competition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("emblemUrl")]
        public object EmblemUrl { get; set; }

        [JsonProperty("plan")]
        public string Plan { get; set; }

        [JsonProperty("currentSeason")]
        public Season CurrentSeason { get; set; }

        [JsonProperty("seasons")]
        public List <Season> Seasons { get; set; }

        [JsonProperty("lastUpdated")]
        [Column(TypeName = "datetime2")]
        public DateTime? LastUpdated { get; set; }
    }
}