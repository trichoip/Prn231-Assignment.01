using EStore.Share.DTOs;

namespace EStore.Repositories
{
    public interface IOrderRepository
    {
        Task<IList<OrderDTO>> FindAllAsync();
        Task<OrderDTO> CreateAsync(OrderDTO entity);
        Task<OrderDTO> UpdateAsync(OrderDTO entity);
        Task DeleteAsync(OrderDTO entity);
        Task<OrderDTO?> FindByIdAsync(int entityId);
    }
}
