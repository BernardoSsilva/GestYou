namespace comunication.responses
{
    public class TransactionByCategoryJsonResponse
    {
        public int CategoryId { get; set; }
        public string CategoryDescription { get; set; } = string.Empty;
        public float TotalRevenues { get; set; }
        public float TotalExpenses { get; set; }
    }
}
