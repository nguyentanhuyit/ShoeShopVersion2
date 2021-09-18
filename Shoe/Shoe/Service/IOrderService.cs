using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public interface IOrderService
    {
        public Order AddOrder(Order order);
        //NguyenDoanMinhNhat
        public List<Order> getAllOrder();
        //NguyenDoanMinhNhat
        public Order getOrderById(int id);
        //NguyenDoanMinhNhat
        public void editOrder(int id, int status);
        //NguyenDoanMinhNhat
        public User getUser(int id);
        //NguyenDoanMinhNhat
        public List<Product> getAllProduct(int id);
        //NguyenDoanMinhNhat
        public List<ShoeSizeDetail> getShoeSizeDetails(int id);
        public List<Order> getOrderByUser(int id);
    }
}
