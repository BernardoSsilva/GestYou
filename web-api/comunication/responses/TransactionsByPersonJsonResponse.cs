using System;
using System.Collections.Generic;
using System.Text;

namespace comunication.responses
{
    public class TransactionsByPersonJsonResponse
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; } = string.Empty;
        public float TotalRevenues { get; set; }
        public float TotalExpenses { get; set; }
        public float Balance { get; set; }
    }
}
