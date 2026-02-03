using domain.entities;
using domain.Repository;
using infra;
using Microsoft.EntityFrameworkCore;

public class TransactionRepository : ITransactionsRepository
{
    private readonly AppDbContext _dbContext;

    public TransactionRepository(AppDbContext context)
    {
        _dbContext = context;
    }

    public async Task CreateTransaction(TransactionEntity transaction)
    {
        await _dbContext.Transactions.AddAsync(transaction);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<TransactionEntity>> GetAllTransactions()
    {
        return await _dbContext.Transactions
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task UpdateTransaction(int transactionId, TransactionEntity transaction)
    {
        var existing = await _dbContext.Transactions.FindAsync(transactionId);
        if (existing == null) return;

        existing.Description = transaction.Description;
        existing.Value = transaction.Value;
        existing.Type = transaction.Type;
        existing.CategoryId = transaction.CategoryId;
        existing.PersonId = transaction.PersonId;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteTransaction(TransactionEntity data)
    {

        _dbContext.Transactions.Remove(data);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<TransactionEntity?> GetTransactionById(int id)
    {
        return await _dbContext.Transactions.FindAsync(id);
    }
}
