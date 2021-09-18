using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoe.Service;


namespace Shoe.Controllers
{
    public class AdminOrderController : Controller
    {
      
        private IOrderService OrderService;
        public AdminOrderController(IOrderService  order)
        {
            OrderService = order;
        }

        // GET: Order
        public ActionResult Index()
        {
            return View(OrderService.getAllOrder());
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            ViewData["User"] = OrderService.getUser(id);
            ViewData["Products"] = OrderService.getAllProduct(id);
            ViewData["ShoeSizeDetails"] = OrderService.getShoeSizeDetails(id);
            return View(OrderService.getOrderById(id));
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View(OrderService.getOrderById(id));
        }
        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            OrderService.editOrder(id, int.Parse(collection["status"]));
            return RedirectToAction("Index");
        }
    }
}