using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public interface ISizeService
    {
        public List<Size> getListSizeByProductID(int productID);
        public List<Size> getAll();
        public Size getByName(string name);
    }
}
