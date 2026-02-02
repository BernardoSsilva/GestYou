using domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain.Repository
{
    public interface IPersonRepository
    {
        Task CreatePerson(PersonEntity data);
        Task<List<PersonEntity>> GetAllPersons();

        Task<PersonEntity?> GetPersonById(int id);
        Task UpdatePerson(int PersonId, PersonEntity data);
        Task DeletePerson(PersonEntity data);
    }
}
