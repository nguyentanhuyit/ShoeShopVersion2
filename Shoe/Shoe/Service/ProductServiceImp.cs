using Shoe.Models.DBModels;
using Shoe.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public class ProductServiceImp : IProductService
    {
        private IProductDAO productDAO;
        public ProductServiceImp(IProductDAO product)
        {
            productDAO = product;
        }

        public List<Product> getAllProduct()
        {
            return productDAO.getAllProduct();
        }

        public List<Product> getAllProductByGender(string gender)
        {
            return productDAO.getAllProductByGender(gender);
        }

        public List<Product> getListProductByGenderAndCategory(string gender, string category)
        {
            return productDAO.getListProductByGenderAndCategory(gender, category);
        }

        public Product getProductById(int id)
        {
            return productDAO.getProductById(id);
        }

        public Product GetProductByShoeSizeID(int shoeSizeID)
        {
            return productDAO.GetProductByShoeSizeID(shoeSizeID);
        }

        public List<Product> searchProduct(string keyWork)
        {
            return productDAO.searchProduct(keyWork);
        }

        public List<Product> sort(string gender, string category, int minPrice, int maxPrice, string color, int size)
        {
            return productDAO.sort(gender, category, minPrice, maxPrice, color, size);
        }
        //NguyenDoanMinhNhat
        public void editProduct(int id, string name, string gender, string color, string discription, int category_id, int price)
        {
            productDAO.editProduct(id, name, gender, color, discription, category_id, price);
        }
        //NguyenDoanMinhNhat
        public Product createProduct(string name, string gender, string color, string discription, int category_id, int price)
        {
            return productDAO.CreateProduct(name, gender, color, discription, category_id, price);
        }
        //NguyenDoanMinhNhat
        public void deleteProduct(int id)
        {
            productDAO.deleteProduct(id);
        }
        //NguyenDoanMinhNhat
        public void UploadImage(int id)
        {
            productDAO.UploadImage(id);
        }
        //NguyenDoanMinhNhat
        public List<ShoeSizeDetail> getShoeSizeDetails(int id)
        {
            return productDAO.getShoeSizeDetails(id);
        }

        public Product getProductById(int? shoeSizeId)
        {
            throw new NotImplementedException();
        }
    }
}
