using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    [Serializable]
    public class News
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty(PropertyName = "newsId")]
        public string NewsId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [DataType(DataType.Text)]
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [DataType(DataType.Text)]
        [JsonProperty(PropertyName = "author")]
        public string Author { get; set; }

        [DataType(DataType.Text)]
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [DataType(DataType.Url)]
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [DataType(DataType.Url)]
        [JsonProperty(PropertyName = "urlToImage")]
        public string UrlToImage { get; set; }

        [DataType(DataType.Date)]
        [JsonProperty(PropertyName = "publishedAt")]
        public DateTime PublishedAt { get; set; }

        [DataType(DataType.Text)]
        [JsonProperty(PropertyName = "source")]
        public Source Source { get; set; }

        [DataType(DataType.Text)]
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [DataType(DataType.Text)]
        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }

        [DataType(DataType.Text)]
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
    }
}
