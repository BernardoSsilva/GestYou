using application.UseCases.Categories.Interfaces;
using application.UseCases.Transactions.Interfaces;
using AutoMapper;
using comunication.requests;
using domain.entities;
using domain.Repository;

namespace application.UseCases.Transactions
{
    public class UpdateTransactionUseCase : IUpdateTransaction
    {
        private readonly ITransactionsRepository _repository;
        private readonly IMapper _mapper;

        public UpdateTransactionUseCase(ITransactionsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Execute(int transactionId, TransactionDto data)
        {
            try
            {

                var transaction = await _repository.GetTransactionById(transactionId);

                if (transaction == null)
                {
                    throw new KeyNotFoundException();
                }
                await _repository.UpdateTransaction(transactionId, _mapper.Map<TransactionEntity>(data));
            } catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
