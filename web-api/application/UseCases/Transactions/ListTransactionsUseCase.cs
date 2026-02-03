using application.UseCases.Transactions.Interfaces;
using AutoMapper;
using comunication.responses;
using domain.Repository;

namespace application.UseCases.Transactions
{
    public class ListTransactionsUseCase : IListTransactions
    {
        private readonly ITransactionsRepository _repository;
        private readonly IMapper _mapper;
        public ListTransactionsUseCase(ITransactionsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<TransactionJsonResponse>> Execute()
        {
            var result = await _repository.GetAllTransactions();


            return _mapper.Map< List<TransactionJsonResponse>>( result );
        }
    }
}
