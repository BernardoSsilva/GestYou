using application.UseCases.Categories.Interfaces;
using application.UseCases.Persons.Interfaces;
using AutoMapper;
using comunication.requests;
using domain.entities;
using domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace application.UseCases.Categories
{
    public class CreateCategoryUseCase:ICreateCategory
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        public CreateCategoryUseCase(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Execute(CategoryDto data)
        {
            await _repository.CreateCategory(_mapper.Map<CategoryEntity>(data));
        }
    }
}
