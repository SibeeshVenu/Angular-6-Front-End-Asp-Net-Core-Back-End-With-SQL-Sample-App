using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class Source
    {
        [DataType(DataType.Text)]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [DataType(DataType.Text)]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
