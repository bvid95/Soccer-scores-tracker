using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RVAS.Models
{
    public class HeadStanding

    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("competition")]
        public Competition Competition { get; set; }

        [JsonProperty("season")]
        public Season Season { get; set; }

        [JsonProperty("standings")]
        public List<Standing> Standings { get; set; }
    }
}