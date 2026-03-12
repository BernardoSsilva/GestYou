using domain.entities;
using domain.Enums;
using infra;
using Microsoft.EntityFrameworkCore;

namespace tests.InfrastructureTests.RepositoriesTests
{
    public class CategoryRepositoryTest
    {

        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task CreateNewCategoryTest()
        {
            var context = GetDbContext();

            CategoryEntity newEntity = new CategoryEntity("Description test", CategoryFinalityEnum.Both);

            CategoryRepository repository = new CategoryRepository(context);

            await repository.CreateCategory(newEntity);

            var result = await context.Categories.ToListAsync();

            Assert.Single(result);
            Assert.Equal("Description test", result[0].Description);
            Assert.Equal(CategoryFinalityEnum.Both, result[0].Finality);


        }

        [Fact]
        public async Task DeleteCategoryTest() {
            var context = GetDbContext();
            CategoryEntity newEntity = new CategoryEntity("Description test",CategoryFinalityEnum.Both);
            CategoryRepository repository = new CategoryRepository(context);

            await repository.CreateCategory(newEntity);
            Assert.Single(await context.Categories.ToListAsync());

            await repository.DeleteCategory(newEntity);
            var result = await context.Categories.ToListAsync();

            Assert.Empty(result);
        }

        [Fact]
        public async Task UpdateCategoryTest() {
            var context = GetDbContext();

            CategoryEntity newEntity = new CategoryEntity("Description test", CategoryFinalityEnum.Both);

            CategoryRepository repository = new CategoryRepository(context);

            await repository.CreateCategory(newEntity);

            var result = await context.Categories.ToListAsync();

            Assert.Single(result);
            Assert.Equal("Description test", result[0].Description);
            Assert.Equal(CategoryFinalityEnum.Both, result[0].Finality);

            await repository.UpdateCategory(1, new CategoryEntity("Edition test", CategoryFinalityEnum.Revenue));

            var updateResult = await context.Categories.ToListAsync();

            Assert.Single(updateResult);
            Assert.Equal("Edition test", updateResult[0].Description);
            Assert.Equal(CategoryFinalityEnum.Revenue, updateResult[0].Finality);
        }

        [Fact]
        public async Task GetCategoriesListTest()
        {
            var context = GetDbContext();

            CategoryRepository repository = new CategoryRepository(context);

            for (int i = 0; i < 10; i++) {
                CategoryEntity newEntity = new CategoryEntity($"Description test {i}", CategoryFinalityEnum.Both);

                await repository.CreateCategory(newEntity);
            }


            var result = await repository.GetAllCategories();

            Assert.Equal(10, result.Count);
        }

        [Fact]
        public async Task GetCategoryByIdTest()
        {
            var context = GetDbContext();
            CategoryRepository repository = new CategoryRepository(context);
                CategoryEntity newEntity = new CategoryEntity("Description test", CategoryFinalityEnum.Both);
                await repository.CreateCategory(newEntity);


            var result = await repository.GetCategoryById(1);
            var result2 = await repository.GetCategoryById(7);


            Assert.Equal("Description test", result.Description);
            Assert.Equal(CategoryFinalityEnum.Both, result.Finality);
            Assert.Equal(1, result.Id);

            Assert.Null(result2);
        }

    }
}
