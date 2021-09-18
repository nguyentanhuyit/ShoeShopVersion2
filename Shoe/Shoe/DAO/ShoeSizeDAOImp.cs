using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.DAO
{
    public class ShoeSizeDAOImp : IShoeSizeDAO
    {
        private shoeContext _context;
        public ShoeSizeDAOImp(shoeContext shoeContext)
        {
            _context = shoeContext;
        }
        public bool checkQuantity(int productID)
        {
            return true;
        }

        public ShoeSizeDetail getShoeSize(int productID, int sizeID)
        {
            ShoeSizeDetail ss = _context.ShoeSizeDetails.Where(o => o.ProductId == productID && o.SizeId == sizeID).FirstOrDefault();
            return ss;
        }
        //NguyenDoanMinhNhat
        public void addShoseSize(int proID, string name, int quality, int qualitySale)
        {
            Size size = _context.Sizes.Where(s => s.SizeName == name).FirstOrDefault();
            ShoeSizeDetail ssd = _context.ShoeSizeDetails.Where(ss => ss.ProductId == proID && ss.SizeId == size.SizeId).FirstOrDefault();
            if (ssd == null)
            {
                ssd = new ShoeSizeDetail();
                ssd.ProductId = proID;
                ssd.SizeId = size.SizeId;
                ssd.Quatity = quality;
                ssd.QuabtilySale = qualitySale;
                _context.ShoeSizeDetails.Add(ssd);
                _context.Products.Where(p => p.ProductId == proID).FirstOrDefault().ShoeSizeDetails.Add(ssd);
                _context.SaveChanges();
            }
            else
            {
                ssd.Quatity = quality;
                ssd.QuabtilySale = qualitySale;
                _context.SaveChanges();
            }
        }
        //NguyenDoanMinhNhat
        public void removeSizeDetail(int proID, string size)
        {
            int sizeid = _context.Sizes.Where(s => s.SizeName == size).First().SizeId;
            ShoeSizeDetail ssd = _context.ShoeSizeDetails.Where(ss => ss.ProductId == proID && ss.SizeId == sizeid).FirstOrDefault();
            if (ssd != null)
            {
                _context.ShoeSizeDetails.Remove(ssd);
                _context.SaveChanges();
            }
        }
    }
}
