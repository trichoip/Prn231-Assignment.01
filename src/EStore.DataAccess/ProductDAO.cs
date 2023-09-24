using EStore.BusinessObject.Data;
using EStore.BusinessObject.Entities;

namespace EStore.DataAccess
{
    public class ProductDAO : BaseDAO<Product>, IBaseDAO<Product>
    {

        public ProductDAO(FstoreDbContext _context) : base(_context)
        {
        }
    }
}
