using EStore.BusinessObject.Data;
using Microsoft.EntityFrameworkCore;

namespace EStore.DataAccess
{
    public class BaseDAO<T> : IBaseDAO<T> where T : class
    {

        private readonly FstoreDbContext context;

        public BaseDAO(FstoreDbContext _context) => context = _context;

        public async Task<T> CreateAsync(T entity)
        {
            context.Add(entity);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            context.Remove(entity);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            context.Update(entity);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entity;
        }

        public async Task<IList<T>> FindAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T?> FindByIdAsync(object?[] entityId)
        {
            var entity = await context.Set<T>().FindAsync(entityId).AsTask();
            context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

    }
}
