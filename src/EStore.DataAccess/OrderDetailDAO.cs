using EStore.BusinessObject.Data;
using EStore.BusinessObject.Entities;

namespace EStore.DataAccess
{
    public class OrderDetailDAO : BaseDAO<OrderDetail>, IBaseDAO<OrderDetail>
    {
        public OrderDetailDAO(FstoreDbContext _context) : base(_context)
        {

        }
    }
}
