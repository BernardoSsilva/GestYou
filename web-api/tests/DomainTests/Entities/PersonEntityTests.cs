using domain.entities;

namespace tests.DomainTests.Entities
{
    public class PersonEntityTests
    {
        [Fact]
        public void CreateEntityTest()
        {
            string name = "jhon doe";
            int age = 18;

            PersonEntity entity = new PersonEntity(name, age);

            Assert.Equal(name, entity.Name);
            Assert.Equal(age, entity.Age);
        }
    }
}
