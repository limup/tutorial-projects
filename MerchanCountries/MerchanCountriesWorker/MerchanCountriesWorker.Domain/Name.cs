using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MerchanCountriesWorker.Domain
{
    public class Name
    {
        [JsonPropertyName("common")]
        public string Common { get; set; }
    }
}