using EStore.Share.DTOs;

namespace EStore.Repositories
{
    public interface IProductRepository
    {
        Task<IList<ProductDTO>> FindAllAsync();
        Task<ProductDTO> CreateAsync(ProductDTO entity);
        Task<ProductDTO> UpdateAsync(ProductDTO entity);
        Task DeleteAsync(ProductDTO entity);
        Task<ProductDTO?> FindByIdAsync(int entityId);
    }
}
