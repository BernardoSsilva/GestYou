using domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace comunication.requests
{
    public class TransactionDto
    {
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("value")]
        public float Value { get; set; }

        [JsonPropertyName("Type")]
        public TransactionTypeEnum Type { get; set; } = TransactionTypeEnum.Revenue;

        [JsonPropertyName("personId")]
        public int PersonId { get; set; }

        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }
    }
}
