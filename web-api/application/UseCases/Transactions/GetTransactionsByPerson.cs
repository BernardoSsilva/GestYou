using application.UseCases.Transactions.Interfaces;
using AutoMapper;
using comunication.responses;
using domain.Repository;

namespace application.UseCases.Transactions
{
    public class GetTransactionsByPerson: IGetTransactionsByPerson
    {
        private readonly ITransactionsRepository _repository;
        private readonly IPersonRepository _personRepository;

        public GetTransactionsByPerson(ITransactionsRepository repository, IMapper mapper, IPersonRepository personRepository)
        {
            _repository = repository;
            _personRepository = personRepository;
        }

        public async Task<List<TransactionsByPersonJsonResponse>> Execute()
        {
            var groupedTransactions = (await _repository.GetAllTransactions()).GroupBy(x => x.PersonId);

            List<TransactionsByPersonJsonResponse> finalResponse = new();
            foreach(var group in groupedTransactions)
            {
                float totalRevenues = 0;
                float totalExpenses= 0;
                foreach (var transaction in group)
                {
                    if(transaction.Type == domain.Enums.TransactionTypeEnum.Expense)
                    {
                        totalExpenses += transaction.Value;
                    } else
                    {
                        totalRevenues += transaction.Value;
                    }

                }
                float balance = totalRevenues - totalExpenses;

                finalResponse.Add(new TransactionsByPersonJsonResponse
                {
                    Balance = balance,
                    TotalRevenues = totalRevenues,
                    TotalExpenses = totalExpenses,
                    PersonId = group.Key,
                    PersonName = (await _personRepository.GetPersonById(group.Key))!.Name
                });
            }

            return finalResponse;
        }
    }
}
