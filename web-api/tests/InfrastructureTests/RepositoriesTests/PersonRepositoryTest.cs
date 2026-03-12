using domain.entities;
using infra;
using infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace tests.InfrastructureTests.RepositoriesTests
{
    public class PersonRepositoryTests
    {

        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task CreateNewPersonTest()
        {
            var context = GetDbContext();

            PersonEntity newEntity = new PersonEntity("jhon doe", 18);

            PersonRepository repository = new PersonRepository(context);

            await repository.CreatePerson(newEntity);

            var result = await context.Persons.ToListAsync();

            Assert.Single(result);
            Assert.Equal("jhon doe", result[0].Name);
            Assert.Equal(18, result[0].Age);
        }

        [Fact]
        public async Task DeletePersonTest()
        {
            var context = GetDbContext();
            PersonEntity newEntity = new PersonEntity("jhon doe", 18);
            PersonRepository repository = new PersonRepository(context);

            await repository.CreatePerson(newEntity);
            Assert.Single(await context.Persons.ToListAsync());

            await repository.DeletePerson(newEntity);
            var result = await context.Persons.ToListAsync();

            Assert.Empty(result);
        }

        [Fact]
        public async Task UpdatePersonTest()
        {
            var context = GetDbContext();

            PersonEntity newEntity = new PersonEntity("jhon doe", 18);

            PersonRepository repository = new PersonRepository(context);

            await repository.CreatePerson(newEntity);

            var result = await context.Persons.ToListAsync();

            Assert.Single(result);
            Assert.Equal("jhon doe", result[0].Name);
            Assert.Equal(18, result[0].Age);

            await repository.UpdatePerson(1, new PersonEntity("new name test", 20));

            var updateResult = await context.Persons.ToListAsync();

            Assert.Single(updateResult);
            Assert.Equal("new name test", updateResult[0].Name);
            Assert.Equal(20, updateResult[0].Age);
        }

        [Fact]
        public async Task GetPersonsListTest()
        {
            var context = GetDbContext();

            PersonRepository repository = new PersonRepository(context);

            for (int i = 0; i < 10; i++)
            {
                PersonEntity newEntity = new PersonEntity($"Jhon doe {i}", 18 + i);

                await repository.CreatePerson(newEntity);
            }


            var result = await repository.GetAllPersons();

            Assert.Equal(10, result.Count);
        }

        [Fact]
        public async Task GetPersonByIdTest()
        {
            var context = GetDbContext();
            PersonRepository repository = new PersonRepository(context);
            PersonEntity newEntity = new PersonEntity("Jhon doe" , 18);
            await repository.CreatePerson(newEntity);


            var result = await repository.GetPersonById(1);
            var result2 = await repository.GetPersonById(7);


            Assert.Equal("Jhon doe", result.Name);
            Assert.Equal(18, result.Age);
            Assert.Equal(1, result.Id);

            Assert.Null(result2);
        }

    }
}
