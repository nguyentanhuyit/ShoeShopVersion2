using Shoe.DAO;
using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.DAO
{
    public class OrderDAOImp : IOrderDAO
    {
        private shoeContext _context;
        public OrderDAOImp(shoeContext shoeContext)
        {
            _context = shoeContext;
        }
        public Order AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }
        //NguyenDoanMinhNhat
        public List<Order> getAllOrder()
        {
            return _context.Orders.ToList();
        }
        //NguyenDoanMinhNhat
        public Order getOrderById(int id)
        {
            return _context.Orders.Where(o => o.Id == id).FirstOrDefault();
        }
        //NguyenDoanMinhNhat
        public void editOrder(int id, int status)
        {
            Console.WriteLine(status);
            Order order = _context.Orders.Where(o => o.Id == id).FirstOrDefault();
            order.Status = status;
            _context.SaveChanges();
        }
        //NguyenDoanMinhNhat
        public User getUser(int id)
        {
            Order order = _context.Orders.Where(o => o.Id == id).FirstOrDefault();
            return _context.Users.Where(u => u.Id == order.UserId).FirstOrDefault();
        }
        //NguyenDoanMinhNhat
        public List<Product> getAllProduct(int id)
        {
            List<OrderDetail> ods = _context.OrderDetails.Where(od => od.OrderId == id).ToList();
            List<Product> products = new List<Product>();
            foreach (var item in ods)
            {
                ShoeSizeDetail ssd = _context.ShoeSizeDetails.Where(s => s.Id == item.ShoeSizeId).FirstOrDefault();
                Product pro = _context.Products.Where(p => p.ProductId == ssd.ProductId).FirstOrDefault();
                products.Add(pro);
            }
            return products;
        }
        //NguyenDoanMinhNhat
        public List<ShoeSizeDetail> getShoeSizeDetails(int id)
        {
            List<OrderDetail> ods = _context.OrderDetails.Where(o => o.OrderId == id).ToList();
            List<ShoeSizeDetail> ssds = new List<ShoeSizeDetail>();
            foreach (var item in ods)
            {
                ShoeSizeDetail ssd = _context.ShoeSizeDetails.Where(ssd => ssd.Id == item.ShoeSizeId).FirstOrDefault();
                ssds.Add(ssd);
            }
            return ssds;
        }

        public List<Order> getOrderByUser(int id)
        {
            List<Order> order = _context.Orders.Where(o => o.UserId == id).ToList();
            return order;
        }
    }
}
