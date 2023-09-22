using EStore.BusinessObject.Entities;
using EStore.DataAccess;
using EStore.DataAccess.DTOs;

namespace EStore.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly OrderDAO _orderDAO;
        public OrderRepository(OrderDAO orderDAO) => _orderDAO = orderDAO;
        public Order GetOrderByID(int id) => _orderDAO.FindOrderById(id);

        public List<Order> GetOrders() => _orderDAO.GetAllOrders();

        public void SaveOrder(OrderDTO ord) => _orderDAO.AddOrder(ord);

        public void UpdateOrder(int id, OrderDTO ord) => _orderDAO.UpdateOrder(id, ord);
    }
}
