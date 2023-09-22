using EStore.BusinessObject.Entities;
using EStore.DataAccess.DTOs;

namespace EStore.Repositories
{
    public interface IOrderRepository
    {
        void SaveOrder(OrderDTO ord);

        Order GetOrderByID(int id);

        void UpdateOrder(int id, OrderDTO ord);

        List<Order> GetOrders();
    }
}
