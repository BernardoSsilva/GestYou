using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace comunication.requests
{
    public class PersonDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("age")] 
        public int Age { get; set; }
    }
}
