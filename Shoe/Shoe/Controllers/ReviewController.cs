using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoe.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Controllers
{
    public class ReviewController : Controller
    {
        private IReviewService ReviewService;
        public ReviewController(IReviewService review)
        {
            ReviewService = review;
        }
        [HttpPost]
        public JsonResult Comment(int productID, string comment, int rating)
        {
            int UserId = int.Parse(HttpContext.Session.GetString("id"));
            if (HttpContext.Session.GetString("userName") != null)
            {
                return Json(ReviewService.comment(UserId, productID, comment, rating));
            }
                return Json("");
        }
    }
}
