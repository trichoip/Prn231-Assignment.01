using EStore.BusinessObject.Entities;
using EStore.DataAccess.DTOs;

namespace EStore.Repositories
{
    public interface ICategoryRepository
    {
        List<CategoryDTO> categoryResponds();

        Category GetCategoryByID(int id);

        void DeleteCategory(Category cate);

        void UpdateCategory(int id, CategoryDTO cate);

        void CreateCategory(CategoryDTO p);

    }
}
