using domain.entities;
using domain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace infra.Repositories
{
    public class TransactionRepository : ITransactionsRepository
    {
        private readonly AppDbContext _dbContext;
        public TransactionRepository(AppDbContext context)
        {
            _dbContext = context;
        }
        public async Task CreateTransaction(TransactionEntity transaction)
        {
            _dbContext.Transactions.Add(transaction);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTransaction(TransactionEntity transaction)
        {
            _dbContext.Transactions.Remove(transaction);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TransactionEntity>> GetAllTransactions()
        {
            return await _dbContext.Transactions.ToListAsync();
        }

        public async Task UpdateTransaction(TransactionEntity transaction)
        {
            _dbContext.Transactions.Update(transaction);
            await _dbContext.SaveChangesAsync();
        }
    }
}
