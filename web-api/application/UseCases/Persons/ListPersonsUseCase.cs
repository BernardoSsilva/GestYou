using application.UseCases.Persons.Interfaces;
using AutoMapper;
using comunication.responses;
using domain.entities;
using domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace application.UseCases.Persons
{
    public class ListPersonsUseCase : IListPersons
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;
        public ListPersonsUseCase(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<PersonJsonResponse>> Execute()
        {
            var result = await _repository.GetAllPersons();


            return _mapper.Map< List<PersonJsonResponse >>( result );
        }
    }
}
