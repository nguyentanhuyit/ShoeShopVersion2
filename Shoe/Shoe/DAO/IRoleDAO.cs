using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.DAO
{
    public interface IRoleDAO
    {
        public List<Role> getAll();
        public Role getRoleByUser(User user);
    }
}
