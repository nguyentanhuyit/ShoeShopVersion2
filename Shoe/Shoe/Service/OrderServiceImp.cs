using Shoe.DAO;
using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public class OrderServiceImp : IOrderService
    {
        private IOrderDAO orderDAO;
        public OrderServiceImp(IOrderDAO order)
        {
            orderDAO = order;
        }
        public Order AddOrder(Order order)
        {
            return orderDAO.AddOrder(order);
        }

        //NguyenDoanMinhNhat
        public List<Order> getAllOrder()
        {
            return orderDAO.getAllOrder();
        }
        //NguyenDoanMinhNhat
        public Order getOrderById(int id)
        {
            return orderDAO.getOrderById(id);
        }
        //NguyenDoanMinhNhat
        public void editOrder(int id, int status)
        {
            orderDAO.editOrder(id, status);
        }
        //NguyenDoanMinhNhat
        public User getUser(int id)
        {
            return orderDAO.getUser(id);
        }
        //NguyenDoanMinhNhat
        public List<Product> getAllProduct(int id)
        {
            return orderDAO.getAllProduct(id);
        }
        //NguyenDoanMinhNhat
        public List<ShoeSizeDetail> getShoeSizeDetails(int id)
        {
            return orderDAO.getShoeSizeDetails(id);
        }

        public List<Order> getOrderByUser(int id)
        {
            return orderDAO.getOrderByUser(id);
        }
    }
}
