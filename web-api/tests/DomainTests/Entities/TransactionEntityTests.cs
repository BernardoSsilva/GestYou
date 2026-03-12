using domain.entities;
using domain.Enums;

namespace tests.DomainTests.Entities
{
    public class TransactionEntityTests
    {

        [Fact]

        public void CreateEntityTest()
        {

            string description = "descirption teste";
            float value = 100;
            TransactionTypeEnum type = TransactionTypeEnum.Revenue;
            int personId = 1;
            int categoryId = 1;

            TransactionEntity entity = new TransactionEntity(description, value, type, personId, categoryId);

            Assert.Equal(description, entity.Description);
            Assert.Equal(value, entity.Value);  
            Assert.Equal(type, entity.Type);
            Assert.Equal(personId, entity.PersonId);
            Assert.Equal(categoryId, entity.CategoryId);
        }
    }
}
