using EStore.BusinessObject.Data;
using EStore.BusinessObject.Entities;

namespace EStore.DataAccess
{
    public class CategoryDAO : BaseDAO<Category>, IBaseDAO<Category>
    {
        public CategoryDAO(FstoreDbContext _context) : base(_context)
        {

        }
    }
}
