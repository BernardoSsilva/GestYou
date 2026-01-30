using domain.entities;
using domain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext context)
        {
            _dbContext = context;
        }
        public async Task CreateCategory(CategoryEntity data)
        {
           _dbContext.Categories.Add(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategory(CategoryEntity data)
        {
            _dbContext.Categories.Remove(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<CategoryEntity>> GetAllCategories()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task UpdateCategory(CategoryEntity data)
        {
            _dbContext.Categories.Update(data);
            await _dbContext.SaveChangesAsync();
        }
    }
}
