using domain.entities;
using domain.Repository;
using System.Data.Entity;

namespace infra.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _dbContext;

        public PersonRepository(AppDbContext context)
        {
            _dbContext = context;
        }
        public async Task CreatePerson(PersonEntity data)
        {
            _dbContext.Persons.Add(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePerson(PersonEntity data)
        {
            _dbContext.Persons.Remove(data);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<PersonEntity>> GetAllPersons()
        {
            return await _dbContext.Persons.ToListAsync();
        }

        public async Task UpdatePerson(PersonEntity data)
        {
            _dbContext.Persons.Update(data);
            await _dbContext.SaveChangesAsync();
        }
    }
}
