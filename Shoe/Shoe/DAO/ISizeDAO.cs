using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.DAO
{
    public interface ISizeDAO
    {
        public List<Size> getListSizeByProductID(int productID);
        public Size getByName(string name);
        public List<Size> getAll();
    }
}
