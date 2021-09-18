using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.DAO
{
   public interface IProductDAO
    {
        public List<Product> getAllProduct(); //lấy tất cả sản phẩm
        public List<Product> getAllProductByGender(string gender); // lấy tất cả sản phẩm theo giới tính
        public Product getProductById(int id);  // lấy sản phẩm theo mã sản phẩm
       public List<Product> searchProduct(string keyWork); //tìm kiếm sản phẩm
        public List<Product> getListProductByGenderAndCategory(string gender, string category);
        public List<Product> sort(string gender, string category, int minPrice, int maxPrice, string color, int size);
        public Product GetProductByShoeSizeID(int shoeSizeID);
        //NguyenDoanMinhNhat
        public void editProduct(int id, string name, string gender, string color, string discription, int category_id, int price);
        //NguyenDoanMinhNhat      
        public Product CreateProduct(string name, string gender, string color, string discription, int category_id, int price);
        //NguyenDoanMinhNhat
        public void deleteProduct(int id);
        //NguyenDoanMinhNhat
        public void UploadImage(int id);
        //NguyenDoanMinhNhat
        public List<ShoeSizeDetail> getShoeSizeDetails(int id);
        public List<Product> getProductByOrder(int orderID);
    }
}
