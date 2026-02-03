using application.UseCases.Categories.Interfaces;
using AutoMapper;
using domain.Repository;

namespace application.UseCases.Categories
{
    public class DeleteCategoryUseCase:IDeleteCategory
    {

        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly ITransactionsRepository _transactionsRepository;
        public DeleteCategoryUseCase(ICategoryRepository repository, IMapper mapper , ITransactionsRepository transactionsRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _transactionsRepository = transactionsRepository;
        }

        public async Task Execute(int id)
        {

            try
            {

                var category = await _repository.GetCategoryById(id);

                if (category is null)
                {
                    throw new KeyNotFoundException();
                }

                var transactionsByCategory = (await _transactionsRepository.GetAllTransactions()).Where(t => t.CategoryId == id);

                foreach (var transaction in transactionsByCategory)
                {
                    await _transactionsRepository.DeleteTransaction(transaction);
                }

                await _repository.DeleteCategory(category);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
