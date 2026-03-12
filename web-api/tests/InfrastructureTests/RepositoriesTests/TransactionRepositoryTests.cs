using domain.entities;
using domain.Enums;
using infra;
using infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace tests.InfrastructureTests.RepositoriesTests
{
    public class TransactionRepositoryTests
    {

        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task CreateNewTransactionTest()
        {
            var context = GetDbContext();

            TransactionEntity newEntity = new TransactionEntity("description test", (float) 1800.00, TransactionTypeEnum.Expense, 1, 1);

            TransactionRepository repository = new TransactionRepository(context);

            await repository.CreateTransaction(newEntity);

            var result = await context.Transactions.ToListAsync();

            Assert.Single(result);
            Assert.Equal("description test", result[0].Description);
            Assert.Equal(1800.00, result[0].Value);
            Assert.Equal(TransactionTypeEnum.Expense, result[0].Type);
            Assert.Equal(1, result[0].PersonId);
            Assert.Equal(1, result[0].CategoryId);

        }

        [Fact]
        public async Task DeleteTransactionTest()
        {
            var context = GetDbContext();
            TransactionEntity newEntity = new TransactionEntity("description test", (float)1800.00, TransactionTypeEnum.Expense, 1, 1);

            TransactionRepository repository = new TransactionRepository(context);

            await repository.CreateTransaction(newEntity);
            Assert.Single(await context.Transactions.ToListAsync());

            await repository.DeleteTransaction(newEntity);
            var result = await context.Transactions.ToListAsync();

            Assert.Empty(result);
        }

        [Fact]
        public async Task UpdateTransactionTest()
        {
            var context = GetDbContext();

            TransactionEntity newEntity = new TransactionEntity("description test", (float)1800.00, TransactionTypeEnum.Expense, 1, 1);

            TransactionRepository repository = new TransactionRepository(context);

            await repository.CreateTransaction(newEntity);

            var result = await context.Transactions.ToListAsync();

            Assert.Single(result);
            Assert.Equal("description test", result[0].Description);
            Assert.Equal(1800.00, result[0].Value);
            Assert.Equal(TransactionTypeEnum.Expense, result[0].Type);
            Assert.Equal(1, result[0].PersonId);
            Assert.Equal(1, result[0].CategoryId);

            await repository.UpdateTransaction(1, new TransactionEntity("description test 2", (float)3000.00, TransactionTypeEnum.Revenue, 2, 2));

            var updateResult = await context.Transactions.ToListAsync();

            Assert.Single(updateResult);
            Assert.Equal("description test 2", result[0].Description);
            Assert.Equal(3000.00, result[0].Value);
            Assert.Equal(TransactionTypeEnum.Revenue, result[0].Type);
            Assert.Equal(2, result[0].PersonId);
            Assert.Equal(2, result[0].CategoryId);
        }

        [Fact]
        public async Task GetTransactionsListTest()
        {
            var context = GetDbContext();

            TransactionRepository repository = new TransactionRepository(context);

            for (int i = 0; i < 10; i++)
            {
                TransactionEntity newEntity = new TransactionEntity($"description test {i}", (float)1800.00 + (i *1000), TransactionTypeEnum.Expense, 1 + i, 1 + i);

                await repository.CreateTransaction(newEntity);
            }


            var result = await repository.GetAllTransactions();

            Assert.Equal(10, result.Count);
        }

        [Fact]
        public async Task GetTransactionByIdTest()
        {
            var context = GetDbContext();

            TransactionEntity newEntity = new TransactionEntity("description test", (float)1800.00, TransactionTypeEnum.Expense, 1, 1);
            TransactionRepository repository = new TransactionRepository(context);

            await repository.CreateTransaction(newEntity);


            var result = await repository.GetTransactionById(1);
            var result2 = await repository.GetTransactionById(7);

            Assert.NotNull(result);
            Assert.Equal("description test", result.Description);
            Assert.Equal(1800.00, result.Value);
            Assert.Equal(TransactionTypeEnum.Expense, result.Type);
            Assert.Equal(1, result.PersonId);
            Assert.Equal(1, result.CategoryId);

            Assert.Null(result2);
        }

    }
}
