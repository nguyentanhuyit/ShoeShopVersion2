using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public interface IProductService
    {
        public List<Product> getAllProduct();
        public List<Product> getAllProductByGender(string gender);
        public Product getProductById(int id);
        public List<Product> searchProduct(string keyWork);
        public List<Product> getListProductByGenderAndCategory(string gender, string category);
        public List<Product> sort(string gender, string category, int minPrice, int maxPrice, string color, int size);
        public Product GetProductByShoeSizeID(int shoeSizeID);
        Product getProductById(int? shoeSizeId);


        //NguyenDoanMinhNhat
        public void editProduct(int id, string name, string gender, string color, string discription, int category_id, int price);
        //NguyenDoanMinhNhat
        public Product createProduct(string name, string gender, string color, string discription, int category_id, int price);
        //NguyenDoanMinhNhat
        public void deleteProduct(int id);
        //NguyenDoanMinhNhat
        public void UploadImage(int id);
        //NguyenDoanMinhNhat
        public List<ShoeSizeDetail> getShoeSizeDetails(int id);
    }
}
