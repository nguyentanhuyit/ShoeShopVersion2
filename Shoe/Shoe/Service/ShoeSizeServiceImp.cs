using Shoe.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public class ShoeSizeServiceImp : IShoeSizeService
    {
        private IShoeSizeDAO shoeSizeDAO;
        public ShoeSizeServiceImp(IShoeSizeDAO shoeSize)
        {
            shoeSizeDAO = shoeSize;
        }
        public bool checkQuantity(int productID)
        {
            throw new NotImplementedException();
        }
        //NguyenDoanMinhNhat
        public void addShoseSize(int proID, string name, int quality, int qualitySale)
        {
            shoeSizeDAO.addShoseSize(proID, name, quality, qualitySale);
        }
        //NguyenDoanMinhNhat
        public void removeSizeDetail(int proID, string size)
        {
            shoeSizeDAO.removeSizeDetail(proID, size);
        }
    }
}
