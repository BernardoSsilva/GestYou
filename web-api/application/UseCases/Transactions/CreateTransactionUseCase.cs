using application.UseCases.Transactions.Interfaces;
using AutoMapper;
using comunication.requests;
using domain.entities;
using domain.Repository;

namespace application.UseCases.Transactions
{
    public class CreateTransactionUseCase:ICreateTransaction
    {
        private readonly ITransactionsRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPersonRepository _personRepository;

        public CreateTransactionUseCase(ITransactionsRepository repository, IMapper mapper, IPersonRepository personRepository, ICategoryRepository categoryRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _personRepository = personRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task Execute(TransactionDto data)
        {
            var person = await _personRepository.GetPersonById(data.PersonId);

            if(person is null)
            {
                throw new KeyNotFoundException("Pessoa com id especificado não foi encontrada");
            }

            var category = await _categoryRepository.GetCategoryById(data.CategoryId);

            if (category is null)
            {
                throw new KeyNotFoundException("Categoria com id especificado não foi encontrada");
            }

            await _repository.CreateTransaction(_mapper.Map<TransactionEntity>(data));
        }
    }
}
