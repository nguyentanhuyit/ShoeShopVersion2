using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoe.Models.DBModels;
using Shoe.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Shoe.Controllers
{
    public class CheckoutController : Controller
    {
        private IUserService UserService;
        private ICartItemService ItemService;
        private IProductService ProductService;
        private IOrderService OrderService;
        private IOrderDetailService OrderDetailService;

        public object GenarateUserVerificationLink { get; private set; }

        public CheckoutController(IUserService User, ICartItemService Item, IProductService Product, IOrderService Order, IOrderDetailService OrderDetail)
        {
            UserService = User;
            ItemService = Item;
            ProductService = Product;
            OrderService = Order;
            OrderDetailService = OrderDetail;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("userName") != null)
            {
                int UserId = int.Parse(HttpContext.Session.GetString("id"));
                ViewBag.User = UserService.getUser(UserId);

                List<CartItem> listCart = ItemService.getListCartItem(UserId);
                List<Product> listProduct = new List<Product>();
                int? totalPrice = 0;
                foreach (var item in listCart)
                {
                    Product product = ProductService.GetProductByShoeSizeID((int)item.ShoeSizeId);
                    listProduct.Add(product);
                    totalPrice += product.Price * item.Quantity;
                    ViewBag.ListCartItem = listProduct;
                    ViewBag.ListCart = listCart;
                    ViewBag.TotalPrice = totalPrice;
                }
                return View();
            }
            return Redirect("/Account/Login");
        }
        [HttpPost]
        public IActionResult doCheckout(Order order, string Address, string Province, string District, string Homlet)
        {
            int id = int.Parse( HttpContext.Session.GetString("id"));
            if (HttpContext.Session.GetString("userName") != null)
            {
                order.UserId = int.Parse(HttpContext.Session.GetString("id"));
                order.DateCreated = DateTime.Now;
                order.AddressDelivery = Address + ", " + Homlet + ", " + District + ", " + Province;
                order.Payment = 0;
                order.Status = 0;
                order.Paid = 0;
                Order o = OrderService.AddOrder(order);
                List<CartItem> cartItemList = ItemService.getListCartItem(id);
                foreach(CartItem item in cartItemList)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.OrderId = o.Id;
                    orderDetail.Quantity = item.Quantity;
                    orderDetail.ShoeSizeId = (int)item.ShoeSizeId;
                    OrderDetailService.AddOderDetail(orderDetail);
                }
                ItemService.deleteItemUser(id);

                //send mail
                string GenarateUserVerificationLink = string.Format("{0}://{1}",
                       HttpContext.Request.Scheme, HttpContext.Request.Host);
                User user = UserService.getUser(id);
                var fromMail = new MailAddress("minhhai99.top@gmail.com", "Shoe Store"); // set email    
                var fromEmailpassword = "ndcerngkfsrmdtbd"; // Set mail password     
                var toEmail = new MailAddress(user.Email);

                var smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromMail.Address, fromEmailpassword);

                var Message = new MailMessage(fromMail, toEmail);
                Message.Subject = "Xác nhận mua hàng";
                Message.Body = "<br/> Bạn đã đặt hàng thành công sản phẩm: Giày Thể Thao Nam MWC NATT";
                Message.IsBodyHtml = true;
                smtp.Send(Message);

            }
            return Redirect("/Home/Index");
        }
    }
}
