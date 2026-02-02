using application.UseCases.Persons.Interfaces;
using AutoMapper;
using comunication.requests;
using domain.entities;
using domain.Repository;

namespace application.UseCases.Persons
{
    public class UpdatePersonUseCase : IUpdatePerson
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;

        public UpdatePersonUseCase(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Execute(int personId, PersonDto data)
        {
            try
            {

                var person = await _repository.GetPersonById(personId);

                if (person == null)
                {
                    throw new KeyNotFoundException();
                }
                await _repository.UpdatePerson(personId, _mapper.Map<PersonEntity>(data));
            } catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
