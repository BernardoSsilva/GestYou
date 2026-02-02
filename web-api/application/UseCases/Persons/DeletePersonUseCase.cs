using application.UseCases.Persons.Interfaces;
using AutoMapper;
using domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace application.UseCases.Persons
{
    public class DeletePersonUseCase:IDeletePerson
    {

        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;

        public DeletePersonUseCase(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Execute(int id)
        {

            try
            {

                var person = await _repository.GetPersonById(id);

                if (person is null)
                {
                    throw new KeyNotFoundException();
                }

                await _repository.DeletePerson(person);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
