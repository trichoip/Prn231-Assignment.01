namespace EStore.DataAccess
{
    public interface IBaseDAO<T>
    {
        Task<IList<T>> FindAllAsync();
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T?> FindByIdAsync(int entityId);

    }
}
