using comunication.responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace application.UseCases.Transactions.Interfaces
{
    public interface IGetTransactionsByCategory
    {
        Task<List<TransactionByCategoryJsonResponse>> Execute();
    }
}
