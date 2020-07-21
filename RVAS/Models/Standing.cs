using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RVAS.Models
{
    public class Standing
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("stage")]
        public string Stage { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("group")]
        public object Group { get; set; }

        [JsonProperty("table")]
        public List<Table> Table { get; set; }
    }
}