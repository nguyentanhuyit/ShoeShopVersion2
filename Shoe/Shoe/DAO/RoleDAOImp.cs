using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.DAO
{
    public class RoleDAOImp : IRoleDAO
    {
        private shoeContext _context;
        public RoleDAOImp(shoeContext shoeContext)
        {
            _context = shoeContext;
        }
        public List<Role> getAll()
        {
            return _context.Roles.ToList();
        }

        public Role getRoleByUser(User user)
        {
            Role role = (from r in _context.Roles
                         join ur in _context.UserRoles
                         on r.Id equals ur.RoleId
                         where ur.UserId == user.Id
                         select new Role
                         {
                             Id = r.Id,
                             RoleName = r.RoleName
                         }).FirstOrDefault();
            return role;
        }
    }
}
