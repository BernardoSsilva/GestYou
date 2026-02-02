using application.UseCases.Persons.Interfaces;
using AutoMapper;
using comunication.requests;
using domain.entities;
using domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace application.UseCases.Persons
{
    public class CreatePersonUseCase : ICreatePerson
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;
        public CreatePersonUseCase(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Execute(PersonDto data)
        {
            await _repository.CreatePerson(_mapper.Map<PersonEntity>(data));
        }
    }
}
