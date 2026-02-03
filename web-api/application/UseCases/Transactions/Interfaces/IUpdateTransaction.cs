using comunication.requests;

namespace application.UseCases.Transactions.Interfaces
{
    public interface IUpdateTransaction
    {
        Task Execute(int transactionId, TransactionDto data);

    }
}
