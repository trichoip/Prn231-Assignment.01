using EStore.BusinessObject.Data;
using EStore.BusinessObject.Entities;

namespace EStore.DataAccess
{
    public class OrderDAO : BaseDAO<Order>, IBaseDAO<Order>
    {
        public OrderDAO(FstoreDbContext _context) : base(_context)
        {
        }
    }

}
