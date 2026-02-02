using domain.entities;
using domain.Repository;
using infra;
using Microsoft.EntityFrameworkCore;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _dbContext;

    public CategoryRepository(AppDbContext context)
    {
        _dbContext = context;
    }

    public async Task CreateCategory(CategoryEntity data)
    {
        await _dbContext.Categories.AddAsync(data);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<CategoryEntity>> GetAllCategories()
    {
        return await _dbContext.Categories
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task UpdateCategory(int categoryId, CategoryEntity data) {
        var category = await _dbContext.Categories.FindAsync(categoryId);

        if (category == null) return;
        category.Description = data.Description;
        category.Finality = data.Finality;

        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteCategory(CategoryEntity data)
    {

        _dbContext.Categories.Remove(data);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<CategoryEntity?> GetCategoryById(int categoryId)
    {
        return await _dbContext.Categories.FindAsync(categoryId);
    }
}
