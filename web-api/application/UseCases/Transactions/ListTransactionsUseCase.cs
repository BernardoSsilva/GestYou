using application.UseCases.Transactions.Interfaces;
using AutoMapper;
using comunication.responses;
using domain.Repository;

namespace application.UseCases.Transactions
{
    public class ListTransactionsUseCase : IListTransactions
    {
        private readonly ITransactionsRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public ListTransactionsUseCase(ITransactionsRepository repository, IMapper mapper, ICategoryRepository categoryRepository, IPersonRepository personRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _personRepository = personRepository;
        }
        public async Task<List<TransactionJsonResponse>> Execute()
        {
            var result = await _repository.GetAllTransactions();

            List<TransactionJsonResponse> parsedResult = new List<TransactionJsonResponse>();
            foreach(var transaction in result)
            {
                var person = await _personRepository.GetPersonById(transaction.PersonId);
                var category = await _categoryRepository.GetCategoryById(transaction.CategoryId);

                parsedResult.Add(new TransactionJsonResponse{
                    CategoryId = transaction.CategoryId,
                    CategoryName = category.Description,
                    Description = transaction.Description,
                    Id = transaction.Id,
                    PersonId = transaction.PersonId,
                    PersonName = person.Name,
                    Type = transaction.Type,
                    Value = transaction.Value
                });
            }

            return parsedResult;
        }
    }
}
