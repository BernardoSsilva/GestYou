using domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain.entities
{
    public class TransactionEntity
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public float Value { get; set; }
        public TransactionTypeEnum Type { get; set; } = TransactionTypeEnum.Revenue;

        public int PersonId { get; set; }

        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public PersonEntity Person { get; set; }
    }
}
