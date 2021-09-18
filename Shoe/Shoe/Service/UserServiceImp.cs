using Shoe.DAO;
using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public class UserServiceImp : IUserService
    {
        private IUserDAO userDAO;
        public UserServiceImp(IUserDAO user)
        {
            userDAO = user;
        }

        public User getUser(int id)
        {
            return userDAO.getUser(id);
        }

        public void saveChanges()
        {
            userDAO.saveChanges();
        }

        public User findUser(User userForgotPass)
        {
            return userDAO.findUser(userForgotPass);
        }

        public User login(User userLogin)
        {
            return userDAO.login(userLogin);
        }
        public User register(User userRegister)
        {
            return userDAO.register(userRegister);
        }

        public bool VerifyEmail(string email)
        {
            return userDAO.VerifyEmail(email);
        }

        public bool VerifyUsername(string username)
        {
            return userDAO.VerifyUsername(username);
        }

        public User checkResetPassCode(User userChangePass)
        {
            return userDAO.checkResetPassCode(userChangePass);
        }

        public User checkActivationLink(string id)
        {
            return userDAO.checkActivationLink(id);
        }
        public User CheckCurrentPass(string username, string password)
        {
            return userDAO.CheckCurrentPass(username, password);
        }

        public User FindUsername(string username)
        {
            return userDAO.FindUsername(username);
        }


        //NguyenDoanMinhNhat2
        public List<User> getAllUser()
        {
            return userDAO.getAllUser();
        }
        public Role getRole(int id)
        {
            return userDAO.getRole(id);
        }
        public void edit(int id, int role)
        {
            userDAO.edit(id, role);
        }
        public void delete(int id)
        {
            userDAO.delete(id);
        }
        public User create(string userName, string password, int role, string email, string phoneNumber, string address, int verified, DateTime birthday, string name, string gender)
        {
            return userDAO.create(userName, password, role, email, phoneNumber, address, verified, birthday, name, gender);
        }
        public bool checkUserName(string userName)
        {
            return userDAO.checkUserName(userName);
        }
        public bool checkEmail(string email)
        {
            return userDAO.checkEmail(email);
        }
    }
}
