using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public interface IShoeSizeService
    {
        public bool checkQuantity(int productID);
        //NguyenDoanMinhNhat
        public void addShoseSize(int proID, string name, int quality, int qualitySale);
        //NguyenDoanMinhNhat
        public void removeSizeDetail(int proID, string size);
    }
}
