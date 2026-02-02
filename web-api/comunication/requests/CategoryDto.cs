using domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace comunication.requests
{
    public class CategoryDto
    {
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("finality")]
        public CategoryFinalityEnum Finality { get; set; } = CategoryFinalityEnum.Both;
    }
}
