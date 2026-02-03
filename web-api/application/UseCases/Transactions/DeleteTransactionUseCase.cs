using application.UseCases.Transactions.Interfaces;
using AutoMapper;
using domain.Repository;

namespace application.UseCases.Transactions
{
    public class DeleteTransactionUseCase:IDeleteTransaction
    {

        private readonly ITransactionsRepository _repository;
        private readonly IMapper _mapper;

        public DeleteTransactionUseCase(ITransactionsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Execute(int id)
        {

            try
            {

                var transaction = await _repository.GetTransactionById(id);

                if (transaction is null)
                {
                    throw new KeyNotFoundException();
                }

                await _repository.DeleteTransaction(transaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
