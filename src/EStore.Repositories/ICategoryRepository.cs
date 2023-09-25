using EStore.Share.DTOs;

namespace EStore.Repositories
{
    public interface ICategoryRepository
    {
        Task<IList<CategoryDTO>> FindAllAsync();
        Task<CategoryDTO> CreateAsync(CategoryDTO entity);
        Task<CategoryDTO> UpdateAsync(CategoryDTO entity);
        Task DeleteAsync(CategoryDTO entity);
        Task<CategoryDTO?> FindByIdAsync(int entityId);

    }
}
