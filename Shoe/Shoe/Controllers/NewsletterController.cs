using Microsoft.AspNetCore.Mvc;
using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Controllers
{
    public class NewsletterController : Controller
    {
        private INewsletterService newsletterService;
        public NewsletterController(INewsletterService newsletter)
        {
            newsletterService = newsletter;
        }
        /* check email if user subcribed */
        [AcceptVerbs("GET", "POST")]
        public IActionResult CheckSubcribe(string email)
        {
            if (!newsletterService.CheckSubcribe(email))
            {
                return Json($"Email này đã đăng kí rồi!");
            }
            return Json(true);
        }
    }
}
