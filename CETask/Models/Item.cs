using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CETask.Models
{
    public class Item
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
        [JsonProperty(PropertyName = "EntryID")]
        public string EntryID { get; set; }
        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }

        [JsonProperty("Properties")]
        public Dictionary<string, string> ValuesProperties { get; set; }
    }
}
