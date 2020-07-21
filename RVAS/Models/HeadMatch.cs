using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RVAS.Models
{
    public class HeadMatch
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("head2head")]
        public Head2Head Head2Head { get; set; }

        [JsonProperty("match")]
        public Match Match { get; set; }
    }
}