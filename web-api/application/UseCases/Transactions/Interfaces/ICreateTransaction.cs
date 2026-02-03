using comunication.requests;

namespace application.UseCases.Transactions.Interfaces
{
    public interface ICreateTransaction
    {
        Task Execute(TransactionDto data);
    }
}
