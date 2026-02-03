namespace application.UseCases.Transactions.Interfaces
{
    public interface IDeleteTransaction
    {
        Task Execute(int id);
    }
}
