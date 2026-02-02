using application.UseCases.Categories.Interfaces;
using AutoMapper;
using comunication.responses;
using domain.Repository;

namespace application.UseCases.Categories
{
    public class ListCategoriesUseCase : IListCategories
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        public ListCategoriesUseCase(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<CategoryJsonResponse>> Execute()
        {
            var result = await _repository.GetAllCategories();


            return _mapper.Map< List<CategoryJsonResponse >>( result );
        }
    }
}
