using EStore.Share.DTOs;

namespace EStore.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<IList<OrderDetailDTO>> FindAllAsync();
        Task<OrderDetailDTO> CreateAsync(OrderDetailDTO entity);
        Task<OrderDetailDTO> UpdateAsync(OrderDetailDTO entity);
        Task DeleteAsync(OrderDetailDTO entity);
        Task<OrderDetailDTO?> FindByIdAsync(int entityId, int entityId2);
    }
}
