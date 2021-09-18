using Shoe.DAO;
using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public class SizeServiceImp : ISizeService
    {
        private ISizeDAO sizeDAO;
        public SizeServiceImp(ISizeDAO size)
        {
            sizeDAO = size;
        }
        public List<Size> getListSizeByProductID(int productID)
        {
            return sizeDAO.getListSizeByProductID(productID);
        }
        public Size getByName(string name)
        {
            return sizeDAO.getByName(name);
        }
        public List<Size> getAll()
        {
            return sizeDAO.getAll();
        }
    }
}
