using application.UseCases.Categories.Interfaces;
using AutoMapper;
using domain.Repository;

namespace application.UseCases.Categories
{
    public class DeleteCategoryUseCase:IDeleteCategory
    {

        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public DeleteCategoryUseCase(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

                await _repository.DeleteCategory(category);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
