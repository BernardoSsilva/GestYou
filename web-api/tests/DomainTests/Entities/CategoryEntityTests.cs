using domain.entities;
using domain.Enums;

namespace tests.DomainTests.Entities
{
    public class CategoryEntityTests
    {
        [Fact]

        public void CreateEntityTest()
        {
            string description = "Test Description";
            CategoryFinalityEnum finality = CategoryFinalityEnum.Both;

            CategoryEntity entity = new CategoryEntity(description, finality);

            Assert.Equal(description, entity.Description);  
            Assert.Equal(finality, entity.Finality);
        }
    }
}
