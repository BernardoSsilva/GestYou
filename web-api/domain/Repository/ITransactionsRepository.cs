using domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain.Repository
{
    public interface ITransactionsRepository
    {
        Task CreateTransaction(TransactionEntity transaction);
        Task DeleteTransaction(TransactionEntity transaction);
        Task<List<TransactionEntity>> GetAllTransactions();
        Task UpdateTransaction(TransactionEntity transaction);
    }
}
