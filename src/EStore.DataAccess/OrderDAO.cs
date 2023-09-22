using EStore.BusinessObject.Data;
using EStore.BusinessObject.Entities;
using EStore.DataAccess.DTOs;

namespace EStore.DataAccess
{
    public class OrderDAO
    {
        private readonly FstoreDbContext _context;

        public OrderDAO(FstoreDbContext context) => _context = context;

        public List<Order> GetAllOrders()
        {
            var orders = new List<Order>();
            try
            {
                orders = _context.Orders.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orders;
        }

        public Order FindOrderById(int id)
        {
            Order ord = new Order();
            try
            {
                ord = _context.Orders.SingleOrDefault(p => p.OrderId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ord;
        }

        public void AddOrder(OrderDTO orderRespond)
        {
            try
            {
                var order = new Order
                {
                    MemberId = orderRespond.MemberId,
                    OrderDate = orderRespond.OrderDate,
                    RequiredDate = orderRespond.RequiredDate,
                    ShippedDate = orderRespond.ShippedDate,
                    Freight = orderRespond.Freight,
                };
                _context.Orders.Add(order);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateOrder(int id, OrderDTO orderRespond)
        {
            try
            {
                var orderUpdate = _context.Orders.SingleOrDefault(p => p.OrderId == id);
                orderUpdate.MemberId = orderRespond.MemberId;
                orderUpdate.OrderDate = orderRespond.OrderDate;
                orderUpdate.RequiredDate = orderRespond.RequiredDate;
                orderUpdate.ShippedDate = orderRespond.ShippedDate;
                orderUpdate.Freight = orderRespond.Freight;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

}
