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

                var person = await _repository.GetCategoryById(id);

                if (person is null)
                {
                    throw new KeyNotFoundException();
                }

                await _repository.DeleteCategory(person);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
