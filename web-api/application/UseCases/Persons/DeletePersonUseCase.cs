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
        private readonly ITransactionsRepository _transactionsRepository;
        public DeletePersonUseCase(IPersonRepository repository, IMapper mapper, ITransactionsRepository transactionsRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _transactionsRepository = transactionsRepository;
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

                var transactionsByPerson = (await _transactionsRepository.GetAllTransactions()).Where(t => t.PersonId == id);

                foreach(var transaction in transactionsByPerson)
                {
                    await _transactionsRepository.DeleteTransaction(transaction);
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
