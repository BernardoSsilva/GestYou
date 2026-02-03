using comunication.responses;

namespace application.UseCases.Transactions.Interfaces
{
    public interface IListTransactions
    {

        Task<List<TransactionJsonResponse>> Execute();
    }
}
