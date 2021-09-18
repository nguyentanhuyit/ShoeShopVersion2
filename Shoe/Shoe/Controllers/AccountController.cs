using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shoe.Models.DBModels;
using Shoe.Service;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace Shoe.Controllers
{
    
    public class AccountController : Controller
    {
        private IUserService userService;
        private IUserRoleService userRoleService;
        private IRoleService roleService;
        private IOrderService OrderService;
        public AccountController(IUserService user, IUserRoleService userRole, IRoleService role, IOrderService Order)
        {
            userService = user;
            userRoleService = userRole;
            roleService = role;
            OrderService = Order;
        }
        public IActionResult Index()
        {

            return View();
        }
        /* Login */
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DoLogin([FromForm] User userLogin)
        {

            User user = userService.login(userLogin);
            if (user == null)
            {
                ViewBag.Error = "Thông tin đăng nhập không hợp lệ";
                return View("Login");
            }
            else if (user != null)
            {
                
                if (user.Verified == 1)
                {
                    if (roleService.getRoleByUser(user).Id == 2)
                    {
                        ViewBag.Error = "";
                        HttpContext.Session.SetString("id", user.Id.ToString());
                        HttpContext.Session.SetString("userName", user.Username);
                        HttpContext.Session.SetString("password", user.Password);
                        HttpContext.Session.SetString("email", user.Email);

                        TempData["UserName"] = HttpContext.Session.GetString("userName");
                        TempData.Keep();

                        return Redirect("/AdminHome/Index");
                    }   
                    ViewBag.Error = "";
                    HttpContext.Session.SetString("id", user.Id.ToString());
                    HttpContext.Session.SetString("userName", user.Username);
                    HttpContext.Session.SetString("password", user.Password);
                    HttpContext.Session.SetString("email", user.Email);

                    TempData["UserName"] = HttpContext.Session.GetString("userName");
                    TempData.Keep();

                    return Redirect("/home");
                }
                else
                {
                    SendEmailToUser(user.Email, user.ActivationCode);
                    ViewBag.Error = "Do tài khoản của bạn chưa xác minh email nên chúng tôi đã gửi lại email xác minh cho bạn, vui lòng kiểm tra và xác minh sau đó đăng nhập lại";
                }
            }

            return View("Login");
        }
        /* Logout */
        public ActionResult Logout()
        {
            TempData["UserName"] = HttpContext.Session.GetString("");
            TempData["id"] = HttpContext.Session.GetString("");
            return Redirect("Login");
        }
        /* Register */
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public IActionResult DoRegister([FromForm] User userRegister)
        {


            userRegister.ActivationCode = Guid.NewGuid().ToString();
            userRegister.Password = Models.Common.EncryptMD5(userRegister.Password);
            UserRole userRole = new UserRole();
            User user = userService.register(userRegister);
            userRole.UserId = user.Id;
            userRole.RoleId = 1;
            userRoleService.addUserRole(userRole);
           
            SendEmailToUser(userRegister.Email, userRegister.ActivationCode);

            if (user != null)
            {
                ViewBag.Success = "Đăng ký người dùng thành công, mời bạn kiểm tra email";
            }
            else
            {
                ViewBag.Error = "Đăng ký người dùng không thành công";
            }

            return View("Register");
        }
        /* User Verification */
        [HttpGet]
        public ActionResult UserVerification(string id)
        {
            User user = userService.checkActivationLink(id);
            if (id == null || user == null)
            {
                return Redirect("/home");
            }
            user.Verified = 1;
            user.ActivationCode = "";
            userService.saveChanges();
            ViewBag.Success = "Xác minh Email đã hoàn tất, mời bạn đăng nhập lại.";
            return View("UserVerification");
        }
        /* Send Email To User */
        public void SendEmailToUser(string email, string activationCode)
        {

            string GenarateUserVerificationLink = string.Format("{0}://{1}",
                       HttpContext.Request.Scheme, HttpContext.Request.Host);
            var link = $"{GenarateUserVerificationLink}/Account/UserVerification/" + activationCode;

            var fromMail = new MailAddress("minhhai99.top@gmail.com", "Shoe Store"); // set email    
            var fromEmailpassword = "ndcerngkfsrmdtbd"; // Set mail password     
            var toEmail = new MailAddress(email);

            var smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(fromMail.Address, fromEmailpassword);

            var Message = new MailMessage(fromMail, toEmail);
            Message.Subject = "Xác nhận email đăng ký";
            Message.Body = "<br/> Bạn đã đăng ký thành công." +
                           "<br/> Vui lòng nhấp vào liên kết dưới đây để xác minh tài khoản" +
                           "<br/><br/><a href=" + link + ">" + link + "</a>";
            Message.IsBodyHtml = true;
            smtp.Send(Message);
        }
        /* Verify Email when Register new User*/
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyEmail(string email)
        {
            if (!userService.VerifyEmail(email))
            {
                return Json($"Email {email} đã tồn tại!");
            }
            return Json(true);
        }
        /* Verify Username when Register new User*/
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyUsername(string username)
        {
            if (!userService.VerifyUsername(username))
            {
                return Json($"Tên đăng nhập {username} đã tồn tại!");
            }
            return Json(true);
        }
        /* Forgot Password */
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View("ForgotPassword");
        }
        [HttpPost]
        public IActionResult DoForgotPassword([FromForm] User userForgotPass)
        {
            // Genrate OTP     
            string OTP = GeneratePassword();
            User user = userService.findUser(userForgotPass);
            user.ActivationCode = Guid.NewGuid().ToString();
            user.ResetPassCode = OTP;
            userService.saveChanges();

            ForgetPasswordEmailToUser(user.Email, user.ActivationCode, user.ResetPassCode);
            ViewBag.Success = "Kiểm tra email để đặt lại mật khẩu.";

            return View("ForgotPassword");
        }
        /* Check Email when Forgot Password*/
        [AcceptVerbs("GET", "POST")]
        public IActionResult CheckEmail(string email)
        {
            if (userService.VerifyEmail(email))
            {
                return Json($"Tài khoản {email} không tồn tại!");
            }
            return Json(true);
        }
        public string GeneratePassword()
        {
            string OTPLength = "6";
            string OTP = string.Empty;

            string Chars = string.Empty;
            Chars = "1,2,3,4,5,6,7,8,9,0";

            char[] seplitChar = { ',' };
            string[] arr = Chars.Split(seplitChar);
            string NewOTP = "";
            string temp = "";
            Random rand = new Random();
            for (int i = 0; i < Convert.ToInt32(OTPLength); i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                NewOTP += temp;
                OTP = NewOTP;
            }
            return OTP;
        }
        public void ForgetPasswordEmailToUser(string email, string activationCode, string OTP)
        {

            string GenarateUserVerificationLink = string.Format("{0}://{1}",
                       HttpContext.Request.Scheme, HttpContext.Request.Host);
            var link = $"{GenarateUserVerificationLink}/Account/ResetPassword/" + activationCode;

            var fromMail = new MailAddress("minhhai99.top@gmail.com", "Shoe Store"); // set email    
            var fromEmailpassword = "ndcerngkfsrmdtbd"; // Set mail password     
            var toEmail = new MailAddress(email);

            var smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(fromMail.Address, fromEmailpassword);

            var Message = new MailMessage(fromMail, toEmail);
            Message.Subject = "Xác nhận đặt lại mật khẩu";
            Message.Body = "<br/> Bạn đã quên mật khẩu của mình." +
                           "<br/> Vui lòng nhấp vào liên kết dưới đây để đặt lại mật khẩu mới" +
                           "<br/><br/><a href=" + link + ">" + link + "</a>" +
                           "<br/> OTP for password resetting:" + OTP;
            Message.IsBodyHtml = true;
            smtp.Send(Message);
        }

        /* Reset Password */
        [HttpGet]
        public ActionResult ResetPassword(string id)
        {
            User user = userService.checkActivationLink(id);
            if (id == null || user == null)
            {
                return Redirect("/home");
            }
            return View("ResetPassword");
        }
        [HttpPost]
        public ActionResult DoResetPassword([FromForm] User userChangePass)
        {
            User user = userService.checkResetPassCode(userChangePass);
            if (user != null)
            {
                user.ResetPassCode = "";
                user.Verified = 1;
                user.ActivationCode = Guid.NewGuid().ToString();
                user.Password = Models.Common.EncryptMD5(userChangePass.Password);
                userService.saveChanges();
                return Redirect("ResetPasswordConfirm/" + user.ActivationCode);
            }
            else
            {
                ViewBag.Error = "Xác thực OTP không thành công";
            }
            return View("ResetPassword");
        }
        /* Reset Password Confirm */
        [HttpGet]
        public ActionResult ResetPasswordConfirm(string id)
        {
            User user = userService.checkActivationLink(id);
            if (id == null || user == null)
            {
                return Redirect("/home");
            }
            user.Verified = 1;
            user.ActivationCode = "";
            userService.saveChanges();
            ViewBag.Success = "Đã đặt lại mật khẩu mới, mời bạn đăng nhập lại.";
            return View("ResetPasswordConfirm");
        }
        /* Change Password */
        [HttpGet]
        public IActionResult ChangePassword()
        {
            if (TempData["UserName"] == null)
            {
                return Redirect("/home");
            }
            return View("ChangePassword");
        }
        [HttpPost]
        public IActionResult DoChangePassword([FromForm] User userChangePass)
        {
            string username = TempData["UserName"].ToString();
            string password = Models.Common.EncryptMD5(userChangePass.Password);
            User user = userService.CheckCurrentPass(username, password);
            if (user != null)
            {
                user.Password = Models.Common.EncryptMD5(userChangePass.ConfirmPassword);
                userService.saveChanges();
                ViewBag.Success = "Đổi mật khẩu thành công";
            }
            else
            {
                ViewBag.Error = "Bạn nhập sai mật khẩu hiện tại";
            }
            return View("ChangePassword");
        }
        /* View Profile */
        [HttpGet]
        public IActionResult Profile()
        {
            if (TempData["UserName"] == null)
            {
                return Redirect("/home");
            }
            string username = TempData["UserName"].ToString();
            User user = userService.FindUsername(username);
            //Get Infor
            User infor = new User
            {
                Name = user.Name,
                Username = user.Username,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Address = user.Address,
                Gender = user.Gender,
                Birthday = user.Birthday
            };
            ViewBag.Message = infor;
            //Get Day
            DateTime dateOnly = user.Birthday.Date;
            int year = dateOnly.Year;
            int month = dateOnly.Month;
            int day = dateOnly.Day;
            string day1 = "";
            if (day < 10)
            {
                day1 = "0" + day;
            }
            else
            {
                day1 = "" + day;
            }
            string date = year + "-" + month + "-" + day1;
            ViewBag.Birthday = date;
            //Get Gender
            string gender = user.Gender.ToString();
            ViewBag.Gender = gender;
            return View();
        }
        /* Update Profile */
        [HttpPost]
        public IActionResult Update([FromForm] User userUpdate)
        {
            if (TempData["UserName"] == null)
            {
                return Redirect("/home");
            }
            string username = TempData["UserName"].ToString();
            User user = userService.FindUsername(username);
            user.Name = userUpdate.Name;
            user.PhoneNumber = userUpdate.PhoneNumber;
            user.Address = userUpdate.Address;
            user.Gender = userUpdate.Gender;
            user.Birthday = userUpdate.Birthday;
            userService.saveChanges();
            return Redirect("/Account/Profile");
        }
        public IActionResult Purchase()
        {
            if (TempData["UserName"] == null)
            {
                return Redirect("/home");
            }
            else
            {
                int UserId = int.Parse(HttpContext.Session.GetString("id"));
                string username = TempData["UserName"].ToString();
                ViewBag.username = username;
                List<Order> orderList = OrderService.getOrderByUser(UserId);
                ViewBag.orderList = orderList;
            }
            return View();
        }
    }
}
