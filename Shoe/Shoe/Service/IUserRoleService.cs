using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public interface IUserRoleService
    {
        public UserRole addUserRole(UserRole userRole);
    }
}
