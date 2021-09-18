using Microsoft.AspNetCore.Mvc;
using Shoe.Models.DBModels;
using Shoe.Service;
using System;

namespace Shoe.Controllers
{
    public class ContactController : Controller
    {
        private IContactService contactService;
        public ContactController(IContactService contact)
        {
            contactService = contact;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMessage([FromForm] Contact userMessage)
        {

            if (ModelState.IsValid)
            {
                userMessage.Time = DateTime.Now.ToString();
                contactService.addMessage(userMessage);

                ViewBag.Success = "Đã gửi lời nhắn thành công";
            }
            return View("Index");
        }

    }
}
