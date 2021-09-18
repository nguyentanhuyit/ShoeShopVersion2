using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.DAO
{
    public class SizeDAOImp : ISizeDAO
    {
        private shoeContext _context;
        public SizeDAOImp(shoeContext shoeContext)
        {
            _context = shoeContext;
        }
        public List<Size> getListSizeByProductID(int productID)
        {
            List<Size> listSize = (from s in _context.Sizes
                                   join ss in _context.ShoeSizeDetails
                                   on s.SizeId equals ss.SizeId
                                   where ss.ProductId == productID && ss.Quatity > ss.QuabtilySale
                                   select new Size
                                   {
                                       SizeId = s.SizeId,
                                       SizeName = s.SizeName
                                   }).ToList();
            return listSize;
        }
        public Size getByName(string name)
        {
            return _context.Sizes.Where(s => s.SizeName == name).FirstOrDefault();
        }
        public List<Size> getAll()
        {
            return _context.Sizes.ToList();
        }
    }
}
