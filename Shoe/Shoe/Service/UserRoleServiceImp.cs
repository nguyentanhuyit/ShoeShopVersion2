using Shoe.DAO;
using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public class UserRoleServiceImp : IUserRoleService
    {
        private IUserRoleDAO UserRoleDAO;
        public UserRoleServiceImp(IUserRoleDAO UserRole)
        {
            UserRoleDAO = UserRole;
        }
        public UserRole addUserRole(UserRole userRole)
        {
            return UserRoleDAO.addUserRole(userRole);
        }
    }
}
