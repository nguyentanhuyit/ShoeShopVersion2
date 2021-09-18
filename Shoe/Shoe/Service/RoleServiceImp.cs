using Shoe.DAO;
using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public class RoleServiceImp : IRoleService
    {
        private IRoleDAO roleDAO;
        public RoleServiceImp(IRoleDAO role)
        {
            roleDAO = role;
        }
        public List<Role> getAll()
        {
            return roleDAO.getAll();
        }

        public Role getRoleByUser(User user)
        {
            return roleDAO.getRoleByUser(user);
        }
    }
}
