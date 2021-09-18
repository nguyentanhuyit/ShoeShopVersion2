using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.DAO
{

    public class ProductDAOImp:IProductDAO
    {
        private shoeContext _context;

        public ProductDAOImp(shoeContext ShoeContext)
        {
            _context = ShoeContext;
        }


        public List<Product> getAllProduct() //lấy tất cả sản phẩm
        {
            List<Product> list = _context.Products.ToList();
            return list;
        }

        public List<Product> getAllProductByGender(string gender) // lấy tất cả sản phẩm theo giới tính
        {
            List<Product> list = _context.Products.Where(o=>o.Gender==gender).Take(8).ToList();
            return list;
        }

        public Product getProductById(int id) // lấy sản phẩm theo mã sản phẩm
        {
            Product p = (Product)_context.Products.Where(o => o.ProductId == id).FirstOrDefault();
            return p;
        }

        public List<Product> searchProduct(string keyWork) //tìm kiếm sản phẩm
        {
            List<Product> list = _context.Products.Where(o => o.ProductName.Contains(keyWork) ||
                                                              o.Gender.Contains(keyWork) ||
                                                              o.Color.Contains(keyWork)).ToList();
            return list;
        }

        public List<Product> getListProductByGenderAndCategory(string gender, string categoryName)
        {
            List<Product> list = (from p in _context.Products
                                  join c in _context.Categories
                                  on p.CategoryId equals c.CategoryId
                                 where c.CategoryName ==categoryName
                                  select new Product
                                  {
                                      ProductId = p.ProductId,
                                      ProductName = p.ProductName,
                                      Price = p.Price,
                                      Gender = p.Gender,
                                      Color = p.Color,
                                      Discription = p.Discription,
                                      CategoryId = p.CategoryId,
                                      MainImg = p.MainImg,
                                      Img1 = p.Img1,
                                      Img2 = p.Img2,
                                      Img3 =p.Img3
                                  }).Where(o => o.Gender == gender).Distinct().ToList();
            return list;
        }

        public List<Product> sort(string gender, string category, int minPrice, int maxPrice, string color, int size)
        {
           
            List<Product> list = new List<Product>();
            if (gender != "" && category != "" && color != "" && size != 0)
            {
                list = (from p in _context.Products
                        join c in _context.Categories
                        on p.CategoryId equals c.CategoryId
                        where c.CategoryName == category
                        join sd in _context.ShoeSizeDetails
                        on p.ProductId equals sd.ProductId
                        join s in _context.Sizes
                        on sd.SizeId equals s.SizeId
                        where int.Parse(s.SizeName) == size
                        select new Product
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            Price = p.Price,
                            Gender = p.Gender,
                            Color = p.Color,
                            Discription = p.Discription,
                            CategoryId = p.CategoryId,
                            MainImg = p.MainImg,
                            Img1 = p.Img1,
                            Img2 = p.Img2,
                            Img3 = p.Img3
                        }
                        ).Where(o => o.Gender == gender && o.Price > minPrice && o.Price < maxPrice && o.Color == color).Distinct().ToList();
                return list;
            }
            if (gender != "" && category != "" && color != "" && size == 0)
            {
                list = (from p in _context.Products
                        join c in _context.Categories
                        on p.CategoryId equals c.CategoryId
                        where c.CategoryName == category
                        select new Product
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            Price = p.Price,
                            Gender = p.Gender,
                            Color = p.Color,
                            Discription = p.Discription,
                            CategoryId = p.CategoryId,
                            MainImg = p.MainImg,
                            Img1 = p.Img1,
                            Img2 = p.Img2,
                            Img3 = p.Img3
                        }
                        ).Where(o => o.Gender == gender && o.Price > minPrice && o.Price < maxPrice && o.Color == color).Distinct().ToList();
                return list;
            }
            if (gender != "" && category != "" && color == "" && size != 0)
            {
                list = (from p in _context.Products
                        join c in _context.Categories
                        on p.CategoryId equals c.CategoryId
                        where c.CategoryName == category
                        join sd in _context.ShoeSizeDetails
                        on p.ProductId equals sd.ProductId
                        join s in _context.Sizes
                        on sd.SizeId equals s.SizeId
                        where int.Parse(s.SizeName) == size
                        select new Product
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            Price = p.Price,
                            Gender = p.Gender,
                            Color = p.Color,
                            Discription = p.Discription,
                            CategoryId = p.CategoryId,
                            MainImg = p.MainImg,
                            Img1 = p.Img1,
                            Img2 = p.Img2,
                            Img3 = p.Img3
                        }
                        ).Where(o => o.Gender == gender && o.Price > minPrice && o.Price < maxPrice).Distinct().ToList();
                return list;
            }
            if (gender != "" && category == "" && color != "" && size != 0)
            {
                list = (from p in _context.Products
                        join sd in _context.ShoeSizeDetails
                        on p.ProductId equals sd.ProductId
                        join s in _context.Sizes
                        on sd.SizeId equals s.SizeId
                        where int.Parse(s.SizeName) == size
                        select new Product
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            Price = p.Price,
                            Gender = p.Gender,
                            Color = p.Color,
                            Discription = p.Discription,
                            CategoryId = p.CategoryId,
                            MainImg = p.MainImg,
                            Img1 = p.Img1,
                            Img2 = p.Img2,
                            Img3 = p.Img3
                        }
                        ).Where(o => o.Gender == gender && o.Price > minPrice && o.Price < maxPrice && o.Color == color).Distinct().ToList();
                return list;
            }
            if (gender == "" && category != "" && color != "" && size != 0)
            {
                list = (from p in _context.Products
                        join sd in _context.ShoeSizeDetails
                        on p.ProductId equals sd.ProductId
                        join s in _context.Sizes
                        on sd.SizeId equals s.SizeId
                        where int.Parse(s.SizeName) == size
                        select new Product
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            Price = p.Price,
                            Gender = p.Gender,
                            Color = p.Color,
                            Discription = p.Discription,
                            CategoryId = p.CategoryId,
                            MainImg = p.MainImg,
                            Img1 = p.Img1,
                            Img2 = p.Img2,
                            Img3 = p.Img3
                        }
                        ).Where(o => o.Price > minPrice && o.Price < maxPrice && o.Color == color).Distinct().ToList();
                return list;
            }
            if (gender != "" && category != "" && color == "" && size == 0)
            {
                list = (from p in _context.Products
                        join c in _context.Categories
                        on p.CategoryId equals c.CategoryId
                        where c.CategoryName == category
                        select new Product
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            Price = p.Price,
                            Gender = p.Gender,
                            Color = p.Color,
                            Discription = p.Discription,
                            CategoryId = p.CategoryId,
                            MainImg = p.MainImg,
                            Img1 = p.Img1,
                            Img2 = p.Img2,
                            Img3 = p.Img3
                        }
                        ).Where(o => o.Gender == gender && o.Price > minPrice && o.Price < maxPrice).Distinct().ToList();
                return list;
            }
            if (gender != "" && category == "" && color != "" && size == 0)
            {

                list = _context.Products.Where(o => o.Gender == gender && o.Price > minPrice && o.Price < maxPrice && o.Color == color).Distinct().ToList();
                return list;
            }
            if (gender == "" && category != "" && color != "" && size == 0)
            {
                list = (from p in _context.Products
                        join c in _context.Categories
                        on p.CategoryId equals c.CategoryId
                        where c.CategoryName == category
                        select new Product
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            Price = p.Price,
                            Gender = p.Gender,
                            Color = p.Color,
                            Discription = p.Discription,
                            CategoryId = p.CategoryId,
                            MainImg = p.MainImg,
                            Img1 = p.Img1,
                            Img2 = p.Img2,
                            Img3 = p.Img3
                        }
                        ).Where(o => o.Price > minPrice && o.Price < maxPrice && o.Color == color).Distinct().ToList();
                return list;
            }
            if (gender != "" && category == "" && color == "" && size != 0)
            {
                list = (from p in _context.Products
                        join sd in _context.ShoeSizeDetails
                        on p.ProductId equals sd.ProductId
                        join s in _context.Sizes
                        on sd.SizeId equals s.SizeId
                        where int.Parse(s.SizeName) == size
                        select new Product
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            Price = p.Price,
                            Gender = p.Gender,
                            Color = p.Color,
                            Discription = p.Discription,
                            CategoryId = p.CategoryId,
                            MainImg = p.MainImg,
                            Img1 = p.Img1,
                            Img2 = p.Img2,
                            Img3 = p.Img3
                        }
                        ).Where(o => o.Gender == gender && o.Price > minPrice && o.Price < maxPrice).Distinct().ToList();
                return list;
            }
            if (gender == "" && category != "" && color == "" && size != 0)
            {
                list = (from p in _context.Products
                        join c in _context.Categories
                        on p.CategoryId equals c.CategoryId
                        where c.CategoryName == category
                        join sd in _context.ShoeSizeDetails
                        on p.ProductId equals sd.ProductId
                        join s in _context.Sizes
                        on sd.SizeId equals s.SizeId
                        where int.Parse(s.SizeName) == size
                        select new Product
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            Price = p.Price,
                            Gender = p.Gender,
                            Color = p.Color,
                            Discription = p.Discription,
                            CategoryId = p.CategoryId,
                            MainImg = p.MainImg,
                            Img1 = p.Img1,
                            Img2 = p.Img2,
                            Img3 = p.Img3
                        }
                        ).Where(o => o.Price > minPrice && o.Price < maxPrice).Distinct().ToList();
                return list;
            }
            if (gender == "" && category == "" && color != "" && size != 0)
            {
                list = (from p in _context.Products
                        join sd in _context.ShoeSizeDetails
                        on p.ProductId equals sd.ProductId
                        join s in _context.Sizes
                        on sd.SizeId equals s.SizeId
                        where int.Parse(s.SizeName) == size
                        select new Product
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            Price = p.Price,
                            Gender = p.Gender,
                            Color = p.Color,
                            Discription = p.Discription,
                            CategoryId = p.CategoryId,
                            MainImg = p.MainImg,
                            Img1 = p.Img1,
                            Img2 = p.Img2,
                            Img3 = p.Img3
                        }
                        ).Where(o => o.Price > minPrice && o.Price < maxPrice && o.Color == color).Distinct().ToList();
                return list;
            }
            if (gender != "" && category == "" && color == "" && size == 0)
            {
                list = _context.Products.Where(o => o.Gender == gender && o.Price > minPrice && o.Price < maxPrice).Distinct().ToList();
                return list;
            }
            if (gender == "" && category != "" && color == "" && size == 0)
            {
                list = (from p in _context.Products
                        join c in _context.Categories
                        on p.CategoryId equals c.CategoryId
                        where c.CategoryName == category
                        select new Product
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            Price = p.Price,
                            Gender = p.Gender,
                            Color = p.Color,
                            Discription = p.Discription,
                            CategoryId = p.CategoryId,
                            MainImg = p.MainImg,
                            Img1 = p.Img1,
                            Img2 = p.Img2,
                            Img3 = p.Img3
                        }
                        ).Where(o => o.Price > minPrice && o.Price < maxPrice).Distinct().ToList();
                return list;
            }
            if (gender == "" && category == "" && color != "" && size == 0)
            {
                list = _context.Products.Where(o => o.Price > minPrice && o.Price < maxPrice && o.Color == color).Distinct().ToList();
                return list;
            }
            if (gender == "" && category == "" && color == "" && size != 0)
            {
                list = (from p in _context.Products
                        join sd in _context.ShoeSizeDetails
                        on p.ProductId equals sd.ProductId
                        join s in _context.Sizes
                        on sd.SizeId equals s.SizeId
                        where int.Parse(s.SizeName) == size
                        select new Product
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            Price = p.Price,
                            Gender = p.Gender,
                            Color = p.Color,
                            Discription = p.Discription,
                            CategoryId = p.CategoryId,
                            MainImg = p.MainImg,
                            Img1 = p.Img1,
                            Img2 = p.Img2,
                            Img3 = p.Img3
                        }
                        ).Where(o => o.Price > minPrice && o.Price < maxPrice).Distinct().ToList();
                return list;
            }
            if (gender == "" && category == "" && color == "" && size == 0)
            {
                list = _context.Products.ToList();
                return list;
            }
                return list;
        }

        public Product GetProductByShoeSizeID(int shoeSizeID)
        {
            Product product = (from p in _context.Products
                               join ss in _context.ShoeSizeDetails
                               on p.ProductId equals ss.ProductId
                               where ss.Id == shoeSizeID
                               select new Product
                               {
                                   ProductId = p.ProductId,
                                   ProductName = p.ProductName,
                                   Price = p.Price,
                                   Gender = p.Gender,
                                   Color = p.Color,
                                   Discription = p.Discription,
                                   CategoryId = p.CategoryId,
                                   MainImg = p.MainImg,
                                   Img1 = p.Img1,
                                   Img2 = p.Img2,
                                   Img3 = p.Img3
                               }).FirstOrDefault();
                return product;
        }
        //NguyenDoanMinhNhat
        public void editProduct(int id, string name, string gender, string color, string discription, int category_id, int price)
        {
            var pro = _context.Products.Where(o => o.ProductId == id).FirstOrDefault();
            pro.ProductName = name;
            pro.Gender = gender;
            pro.Color = color;
            pro.Discription = discription;
            pro.CategoryId = category_id;
            pro.Price = price;
            _context.SaveChanges();
        }
        //NguyenDoanMinhNhat
        public Product CreateProduct(string name, string gender, string color, string discription, int category_id, int price)
        {
            Product pro = new Product();
            pro.ProductName = name;
            pro.Gender = gender;
            pro.Color = color;
            pro.Discription = discription;
            pro.CategoryId = category_id;
            pro.Price = price;

            _context.Products.Add(pro);
            _context.SaveChanges();
            return pro;
        }
        //NguyenDoanMinhNhat
        public void UploadImage(int id)
        {
            Console.WriteLine("==============oksadadasd" + id);
            Product pro = new Product();
            pro = _context.Products.Where(o => o.ProductId == id).FirstOrDefault();
            pro.MainImg = "~/admin/img/" + pro.ProductId + "_main_img.jpg";
            pro.Img1 = "~/admin/img/" + pro.ProductId + "_img_1.jpg";
            pro.Img2 = "~/admin/img/" + pro.ProductId + "_img_2.jpg";
            pro.Img3 = "~/admin/img/" + pro.ProductId + "_img_3.jpg";
            _context.SaveChanges();
        }
        //NguyenDoanMinhNhat
        public void deleteProduct(int id)
        {

            var pro = _context.Products.Where(o => o.ProductId == id).FirstOrDefault();
            _context.ShoeSizeDetails.RemoveRange(_context.ShoeSizeDetails.Where(ssd => ssd.ProductId == id));
            _context.Products.Remove(pro);
            _context.SaveChanges();
        }
        //NguyenDoanMinhNhat
        public List<ShoeSizeDetail> getShoeSizeDetails(int id)
        {
            return _context.ShoeSizeDetails.Where(ssd => ssd.ProductId == id).ToList();
        }

        public List<Product> getProductByOrder(int orderID)
        {
            return null;
        }
    }
}
