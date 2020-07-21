using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RVAS.Models
{
    public class Season
    {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            [JsonProperty("id")]
            public long Id { get; set; }

            [Column(TypeName ="datetime2")]
            [JsonProperty("startDate")]
            public DateTime? StartDate { get; set; }

            [Column(TypeName ="datetime2")]
            [JsonProperty("endDate")]
            public DateTime? EndDate { get; set; }

            [JsonProperty("currentMatchday")]
            public long? CurrentMatchday { get; set; }

            [JsonProperty("winner")]
            public Team Winner { get; set; }
      
    }
}