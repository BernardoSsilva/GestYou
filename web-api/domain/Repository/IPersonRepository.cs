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

        Task UpdatePerson(PersonEntity data);
        Task DeletePerson(PersonEntity data);
    }
}
