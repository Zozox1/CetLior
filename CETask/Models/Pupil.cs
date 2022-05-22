using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CETask.Models
{
    public class Pupil
    {
        [Required]
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
        [JsonProperty(PropertyName = "EntryID")]
        [Required]
        public string EntryID { get; set; }
        [JsonProperty(PropertyName = "Grade")]
        [Required]
        public string Grade { get; set; }
        [JsonProperty(PropertyName = "Name")]
        [Required]
        public string Name { get; set; }

        public string Type { get => "Pupil"; }
    }
}
