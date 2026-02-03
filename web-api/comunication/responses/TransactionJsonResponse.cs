using domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace comunication.responses
{
    public class TransactionJsonResponse
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public float Value { get; set; }

        public TransactionTypeEnum Type { get; set; } = TransactionTypeEnum.Revenue;

        public int PersonId { get; set; }

        public int CategoryId { get; set; }

        public string PersonName { get; set; } = string.Empty;

        public string CategoryName { get; set; } = string.Empty;
    }
}
