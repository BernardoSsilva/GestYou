using application.UseCases.Categories.Interfaces;
using AutoMapper;
using comunication.requests;
using domain.entities;
using domain.Repository;

namespace application.UseCases.Categories
{
    public class UpdateCategoryUseCase : IUpdateCategory
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCategoryUseCase(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Execute(int personId, CategoryDto data)
        {
            try
            {

                var person = await _repository.GetCategoryById(personId);

                if (person == null)
                {
                    throw new KeyNotFoundException();
                }
                await _repository.UpdateCategory(personId, _mapper.Map<CategoryEntity>(data));
            } catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
