using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.DAO
{
    public interface IShoeSizeDAO
    {
        public bool checkQuantity(int productID);

        public ShoeSizeDetail getShoeSize(int productID, int sizeID);
        //NguyenDoanMinhNhat        
        public void addShoseSize(int proID, string name, int quality, int qualitySale);
        //NguyenDoanMinhNhat
        public void removeSizeDetail(int proID, string size);
    }
}
