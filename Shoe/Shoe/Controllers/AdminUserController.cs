using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoe.Models.DBModels;
using Shoe.Service;
using System;

namespace Shoe.Controllers
{
    public class AdminUserController : Controller
    {
        private IUserService UserService;
        private IRoleService RoleService;
        public AdminUserController(IUserService user, IRoleService role)
        {
            UserService = user;
            RoleService = role;
        }
        public ActionResult Index()
        {
            return View(UserService.getAllUser());
        }
        public ActionResult Details(int id)
        {
            ViewData["Role"] = UserService.getRole(id);
            return View(UserService.getUser(id));
        }
        // GET: User/Create
        public ActionResult Create()
        {
            ViewData["Roles"] = RoleService.getAll();
            return View();
        }
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyEmail(string email)
        {
            if (!UserService.VerifyEmail(email))
            {
                return Json($"Email {email} already exists!");
            }
            return Json(true);
        }
        /* Verify Username when Register new User*/
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyUsername(string username)
        {
            if (!UserService.VerifyUsername(username))
            {
                return Json($"User name {username} already exists!");
            }
            return Json(true);
        }
        // POST: User/Create
        [HttpPost]
        public ActionResult Create(IFormCollection collection, int role)
        {
            User user = new User();
            user.Username = collection["UserName"];
            user.Email = collection["Email"];
            user.PhoneNumber = collection["PhoneNumber"];
            user.Address = collection["Address"];
            user.Verified = int.Parse(collection["Verified"]);
            user.Birthday = DateTime.Parse(collection["Birthday"]);
            user.Name = collection["Name"];
            try
            {
                user = UserService.create(collection["UserName"], collection["Password"], role, collection["Email"], collection["PhoneNumber"], collection["Address"], int.Parse(collection["Verified"]), DateTime.Parse(collection["Birthday"]), collection["Name"], collection["Gender"]);
                return RedirectToAction("Index");
               
            }
            catch
            {
                ViewData["Roles"] = RoleService.getAll();
                return View(user);
            }
        }
      
        public ActionResult Edit(int id)
        {
            ViewData["Roles"] = RoleService.getAll();
            return View(UserService.getUser(id));
        }
        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, string role)
        {
            try
            {
                UserService.edit(id, int.Parse(role));
                return RedirectToAction("Index");
            }
            catch
            {
                ViewData["Roles"] = RoleService.getAll();
                return View(UserService.getUser(id));
            }
        }
        public ActionResult Delete(int id)
        {
            Console.WriteLine(id);
            ViewData["Role"] = UserService.getRole(id);
            return View(UserService.getUser(id));
        }
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                UserService.delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewData["Role"] = UserService.getRole(id);
                return View(UserService.getUser(id));
            }
        }
    }
}
