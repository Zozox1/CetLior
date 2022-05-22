using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CETask.Models
{
    public class Teacher
    {
        [Required]
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
        [Required]
        [JsonProperty(PropertyName = "EntryID")]
        public string EntryID { get; set; }
        [Required]
        [JsonProperty(PropertyName = "Subject")]
        public string Subject { get; set; }
        [Required]
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [Required]
        [JsonProperty(PropertyName = "GradesString")]
        public string GradesString { get; set; }
        public string Type { get => "Teacher"; }
    }
}
