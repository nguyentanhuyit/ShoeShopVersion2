using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.DAO
{
    public class UserRoleDAOImp : IUserRoleDAO
    {
        private shoeContext _context;
        public UserRoleDAOImp(shoeContext context)
        {
            _context = context;
        }
        public UserRole addUserRole(UserRole userRole)
        {
            _context.UserRoles.Add(userRole);
            _context.SaveChanges();
            return userRole;
        }
    }
}
