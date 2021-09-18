using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.DAO
{
    public class UserDAOImp : IUserDAO
    {
        private shoeContext _context;
        public UserDAOImp(shoeContext ShoeContext)
        {
            _context = ShoeContext;
        }

        public User getUser(int id)
        {
            User user = _context.Users.Where(o => o.Id == id).FirstOrDefault();
            return user;
        }

        public void saveChanges()
        {
            _context.SaveChanges();
        }

        public User findUser(User userForgotPass)
        {
            User user = _context.Users.Where(o => o.Email.Equals(userForgotPass.Email)).FirstOrDefault();

            return user;
        }

        public User login(User userLogin)
        {
            User user = _context.Users.Where(o => (o.Email.Equals(userLogin.Email) || o.Username.Equals(userLogin.Email)) && o.Password.Equals(Models.Common.EncryptMD5(userLogin.Password))).FirstOrDefault();

            return user;
        }

        public User register(User userRegister)
        {
            _context.Users.Add(userRegister);
            _context.SaveChanges();

            User user = _context.Users.Where(o => o.Email.Equals(userRegister.Email)).FirstOrDefault();

            return user;
        }

        public bool VerifyEmail(string email)
        {
            User user = _context.Users.Where(o => o.Email.Equals(email)).FirstOrDefault();

            if (user == null)
            {
                return true;
            }
            return false;
        }

        public bool VerifyUsername(string username)
        {
            User user = _context.Users.Where(o => o.Username.Equals(username)).FirstOrDefault();

            if (user == null)
            {
                return true;
            }
            return false;
        }

        public User checkResetPassCode(User userChangePass)
        {
            User user = _context.Users.Where(o => o.ResetPassCode == (userChangePass.ResetPassCode)).FirstOrDefault();

            return user;
        }

        public User checkActivationLink(string id)
        {
            User user = _context.Users.Where(o => o.ActivationCode == id).FirstOrDefault();

            return user;
        }
        public User CheckCurrentPass(string username, string password)
        {
            User user = _context.Users.Where(o => o.Username.Equals(username) && o.Password.Equals(password)).FirstOrDefault();
            return user;
        }

        public User FindUsername(string username)
        {
            User user = _context.Users.Where(o => o.Username.Equals(username)).FirstOrDefault();
            return user;
        }
        //NguyenDoanMinhNhat2
        public List<User> getAllUser()
        {
            return _context.Users.ToList();
        }
        public Role getRole(int id)
        {
            UserRole userRole = _context.UserRoles.Where(ur => ur.UserId == id).FirstOrDefault();
            return _context.Roles.Where(r => r.Id == userRole.RoleId).FirstOrDefault();
        }
        public void edit(int id, int role)
        {
            UserRole userRole = _context.UserRoles.Where(ur => ur.UserId == id).FirstOrDefault();
            _context.UserRoles.Remove(userRole);
            _context.SaveChanges();
            UserRole userRole2 = new UserRole();
            userRole2.RoleId = role;
            userRole2.UserId = id;
            _context.UserRoles.Add(userRole2);
            _context.SaveChanges();
        }
        public void delete(int id)
        {
            User user = _context.Users.Where(u => u.Id == id).FirstOrDefault();
            UserRole userRole = _context.UserRoles.Where(ur => ur.UserId == id).FirstOrDefault();
            _context.UserRoles.Remove(userRole);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public User create(string userName, string password, int role, string email, string phoneNumber, string address, int verified, DateTime birthday, string name, string gender)
        {
            User user = new User();
            user.Username = userName;
            user.Password = password;
            user.Email = email;
            user.PhoneNumber = phoneNumber;
            user.Address = address;
            user.Verified = verified;
            user.Birthday = birthday;
            user.Name = name;
            if (gender == "Nam")
                user.Gender = Gender.Nam;
            else if (gender == "Nữ")
                user.Gender = Gender.Nữ;
            else user.Gender = Gender.Khác;

                _context.Users.Add(user);
            _context.SaveChanges();
            UserRole userRole = new UserRole();
            userRole.RoleId = role;
            userRole.UserId = user.Id;
            _context.UserRoles.Add(userRole);
            _context.SaveChanges();
            return user;
        }
        public bool checkUserName(string userName)
        {
            User user = _context.Users.Where(u => u.Username == userName).FirstOrDefault();
            if (user == null) return false;
            else return true;
        }
        public bool checkEmail(string email)
        {
            User user = _context.Users.Where(u => u.Email == email).FirstOrDefault();
            if (user == null) return false;
            else return true;
        }
    }
}
