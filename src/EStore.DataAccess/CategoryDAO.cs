using EStore.BusinessObject.Data;
using EStore.BusinessObject.Entities;
using EStore.DataAccess.DTOs;

namespace EStore.DataAccess
{
    public class CategoryDAO
    {
        private readonly FstoreDbContext context;

        public CategoryDAO(FstoreDbContext _context) => context = _context;

        public List<CategoryDTO> GetCategories()
        {
            var categories = new List<CategoryDTO>();
            try
            {
                categories = context.Categories.Select(c => new CategoryDTO
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                }).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return categories;
        }

        public Category FindCategoryById(int cid)
        {
            Category cate = new Category();
            try
            {
                cate = context.Categories.SingleOrDefault(p => p.CategoryId == cid);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cate;
        }

        public void CreateCategory(CategoryDTO categoryRespond)
        {
            try
            {
                var category = new Category
                {
                    CategoryName = categoryRespond.CategoryName,
                };
                context.Categories.Add(category);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public void DeleteCategory(Category category)
        {
            try
            {
                var cate = context.Categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);
                context.Categories.Remove(cate);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateCategory(int id, CategoryDTO categoryRespond)
        {
            try
            {
                var categoryUpdate = context.Categories.SingleOrDefault(c => c.CategoryId == id);
                categoryUpdate.CategoryName = categoryRespond.CategoryName;
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
