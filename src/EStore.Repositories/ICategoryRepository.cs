using EStore.Share.DTOs;

namespace EStore.Repositories
{
    public interface ICategoryRepository
    {
        Task<IList<CategoryDTO>> FindAllAsync();
        Task<CategoryDTO> CreateAsync(CategoryDTO entity);
        Task<CategoryDTO> UpdateAsync(int id, CategoryDTO productRespond);
        Task DeleteAsync(int id);
        Task<CategoryDTO?> FindByIdAsync(int entityId);

    }
}
