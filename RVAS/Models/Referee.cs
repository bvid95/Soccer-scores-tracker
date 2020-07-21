using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace RVAS.Models
{
    public class Referee
    {
        public Referee(){

            this.Matches = new HashSet<Match>();
        }
            
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("matches")]
        public virtual ICollection<Match> Matches { get; set; }
    }
}