using System;
using Newtonsoft.Json;

namespace WebApi.Models
{
    public class ListItem
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}
