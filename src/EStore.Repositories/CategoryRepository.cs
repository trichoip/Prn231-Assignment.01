using EStore.BusinessObject.Entities;
using EStore.DataAccess;
using EStore.DataAccess.DTOs;

namespace EStore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDAO _categoryDAO;
        public CategoryRepository(CategoryDAO categoryDAO) => _categoryDAO = categoryDAO;
        public List<CategoryDTO> categoryResponds() => _categoryDAO.GetCategories();

        public void CreateCategory(CategoryDTO cate) => _categoryDAO.CreateCategory(cate);

        public void DeleteCategory(Category cate) => _categoryDAO.DeleteCategory(cate);

        public Category GetCategoryByID(int id) => _categoryDAO.FindCategoryById(id);

        public void UpdateCategory(int id, CategoryDTO cate) => _categoryDAO.UpdateCategory(id, cate);

    }
}
