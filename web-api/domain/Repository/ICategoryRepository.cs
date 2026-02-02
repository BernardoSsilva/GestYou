using domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain.Repository
{
    public interface ICategoryRepository
    {
        Task CreateCategory(CategoryEntity data);
        Task UpdateCategory(int categoryId, CategoryEntity data);
        Task DeleteCategory(CategoryEntity data);
        Task<List<CategoryEntity>> GetAllCategories();

        Task<CategoryEntity?> GetCategoryById(int categoryId);
    }
}
