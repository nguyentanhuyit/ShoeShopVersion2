using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public interface IUserService
    {

        public User getUser(int id);
        public User login(User userLogin);
        public User register(User userRegister);
        public bool VerifyEmail(string email);
        public bool VerifyUsername(string username);
        public void saveChanges();
        public User findUser(User userForgotPass);
        public User checkResetPassCode(User userChangePass);
        public User checkActivationLink(string id);
        public User CheckCurrentPass(string username, string password);
        public User FindUsername(string username);

        //NguyenDoanMinhNhat2
        public List<User> getAllUser();
        public Role getRole(int id);
        public void edit(int id, int role);
        public void delete(int id);
        public User create(string userName, string password, int role, string email, string phoneNumber, string address, int verified, DateTime birthday, string name, string gender);
        public bool checkUserName(string userName);
        public bool checkEmail(string email);
    }
}
