using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.DAO
{
    public interface IOrderDAO
    {
        public Order AddOrder(Order order);
        public List<Order> getAllOrder();
        public Order getOrderById(int id);
        public void editOrder(int id, int status);
        public User getUser(int id);
        public List<Product> getAllProduct(int id);
        public List<ShoeSizeDetail> getShoeSizeDetails(int id);
        public List<Order> getOrderByUser(int id);
    }
}
