using domain.entities;
using domain.Repository;
using Microsoft.EntityFrameworkCore;

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
           await _dbContext.Persons.AddAsync(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePerson(PersonEntity data)
        {
            _dbContext.Persons.Remove(data);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<PersonEntity>> GetAllPersons()
        {
            return await _dbContext.Persons.AsNoTracking().ToListAsync(); ;
        }

        public async Task<PersonEntity?> GetPersonById(int id)
        {
            return await _dbContext.Persons
                .FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task UpdatePerson(int PersonId, PersonEntity data)
        {
            var person = await _dbContext.Persons.FindAsync(PersonId);

            if (person is null) return;
            person.Name = data.Name;
            person.Age = data.Age;
            
            await _dbContext.SaveChangesAsync();
        }
    }
}
