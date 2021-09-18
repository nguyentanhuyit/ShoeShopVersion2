using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Shoe.Service;
using Shoe.Models.DBModels;
using System.IO;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace Shoe.Controllers
{
    public class AdminProductController : Controller
    {
        private IShoeSizeService ShoeSizeService;
        private IProductService ProductService;
        private ICategoryService CategoryService;
        private ISizeService SizeService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public AdminProductController(IProductService Product, IShoeSizeService shoeSize, ICategoryService categoryService , ISizeService size, IHostingEnvironment hostingEnvironment)
        {
            ProductService = Product;
            ShoeSizeService = shoeSize;
            CategoryService = categoryService;
            SizeService = size;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Product
        public ActionResult Index()
        {
            ViewData["Categorys"] = CategoryService.getAll();
            return View(ProductService.getAllProduct());
        }
        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            ViewData["Categorys"] = CategoryService.getAll();
            ViewData["ShoeSizeDetails"] = ProductService.getShoeSizeDetails(id);
            ViewData["Sizes"] = SizeService.getAll();
            Console.WriteLine(ProductService.getShoeSizeDetails(id).Count());
            return View(ProductService.getProductById(id));
        }
        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(IFormCollection collection, bool size36, bool size37, bool size38, bool size39, bool size40, bool size41, bool size42, bool size43, bool size44)
        {
            Product pro =new Product();
            try
            {
                pro = ProductService.createProduct(collection["ProductName"], collection["Gender"], collection["Color"], collection["Discription"], int.Parse(collection["CategoryID"]), int.Parse(collection["Price"]));
                int id = pro.ProductId;
                
                if (size36) ShoeSizeService.addShoseSize(id, "36", int.Parse(collection["quality36"]), int.Parse(collection["qualitySale36"]));
                
                if (size37) ShoeSizeService.addShoseSize(id, "37", int.Parse(collection["quality37"]), int.Parse(collection["qualitySale37"]));
                
                if (size38) ShoeSizeService.addShoseSize(id, "38", int.Parse(collection["quality38"]), int.Parse(collection["qualitySale38"]));
               
                if (size39) ShoeSizeService.addShoseSize(id, "39", int.Parse(collection["quality39"]), int.Parse(collection["qualitySale39"]));
                
                if (size40) ShoeSizeService.addShoseSize(id, "40", int.Parse(collection["quality40"]), int.Parse(collection["qualitySale40"]));
                
                if (size41) ShoeSizeService.addShoseSize(id, "41", int.Parse(collection["quality41"]), int.Parse(collection["qualitySale41"]));
                
                if (size42) ShoeSizeService.addShoseSize(id, "42", int.Parse(collection["quality42"]), int.Parse(collection["qualitySale42"]));
                
                if (size43) ShoeSizeService.addShoseSize(id, "43", int.Parse(collection["quality43"]), int.Parse(collection["qualitySale43"]));
                
                if (size44) ShoeSizeService.addShoseSize(id, "44", int.Parse(collection["quality44"]), int.Parse(collection["qualitySale44"]));

                return RedirectToAction("UploadImage", "AdminProduct", new { id});
            }
            catch
            {
                return View(pro);
            }
        }

        public ActionResult UploadImage(int  id)
        {
            
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public ActionResult UploadImage(int id, IFormCollection collection, IFormFile main_img, IFormFile file1, IFormFile file2, IFormFile file3)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (main_img.Length > 0)
                    {
                        _ = upload(id, main_img, "_main_img.jpg");
                    }
                    if (file1.Length > 0)
                    {
                        _ = upload(id, file1, "_img_1.jpg");
                    }
                    if (file2.Length > 0)
                    {
                        _ = upload(id, file2, "_img_2.jpg");
                    }
                    if (file3.Length > 0)
                    {
                        _ = upload(id, file3, "_img_3.jpg");
                    }
                    ViewBag.FileStatus = "File uploaded successfully.";
                }
                catch (Exception)
                {
                    ViewBag.FileStatus = "Error while file uploading.";
                }

                ProductService.UploadImage(id);
            }
            return RedirectToAction("Index");
        }
        async Task upload(int id, IFormFile file, string name)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            string filePath = webRootPath + "/admin/img/" + id + name;
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }
        public ActionResult Edit(int id)
        {
            return View(ProductService.getProductById(id));
        }
        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection, bool size36, bool size37, bool size38, bool size39, bool size40, bool size41, bool size42, bool size43, bool size44)
        {
            try
            {
                ProductService.editProduct(id, collection["ProductName"], collection["Gender"], collection["Color"], collection["Discription"], int.Parse(collection["CategoryId"]), int.Parse(collection["Price"]));
                
                if (size36) ShoeSizeService.addShoseSize(id, "36", int.Parse(collection["quality36"]), int.Parse(collection["qualitySale36"]));
                else ShoeSizeService.removeSizeDetail(id, "36");

                if (size37) ShoeSizeService.addShoseSize(id, "37", int.Parse(collection["quality37"]), int.Parse(collection["qualitySale37"]));
                else ShoeSizeService.removeSizeDetail(id, "37");

                if (size38) ShoeSizeService.addShoseSize(id, "38", int.Parse(collection["quality38"]), int.Parse(collection["qualitySale38"]));
                else ShoeSizeService.removeSizeDetail(id, "38");

                if (size39) ShoeSizeService.addShoseSize(id, "39", int.Parse(collection["quality39"]), int.Parse(collection["qualitySale39"]));
                else ShoeSizeService.removeSizeDetail(id, "39");

                if (size40) ShoeSizeService.addShoseSize(id, "40", int.Parse(collection["quality40"]), int.Parse(collection["qualitySale40"]));
                else ShoeSizeService.removeSizeDetail(id, "40");

                if (size41) ShoeSizeService.addShoseSize(id, "41", int.Parse(collection["quality41"]), int.Parse(collection["qualitySale41"]));
                else ShoeSizeService.removeSizeDetail(id, "41");

                if (size42) ShoeSizeService.addShoseSize(id, "42", int.Parse(collection["quality42"]), int.Parse(collection["qualitySale42"]));
                else ShoeSizeService.removeSizeDetail(id, "42");

                if (size43) ShoeSizeService.addShoseSize(id, "43", int.Parse(collection["quality43"]), int.Parse(collection["qualitySale43"]));
                else ShoeSizeService.removeSizeDetail(id, "43");

                if (size44) ShoeSizeService.addShoseSize(id, "44", int.Parse(collection["quality44"]), int.Parse(collection["qualitySale44"]));
                else ShoeSizeService.removeSizeDetail(id, "44");
                return RedirectToAction("Index");
            }

            catch {
                return View(ProductService.getProductById(id));
            }
        }
// GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            ViewData["Categorys"] = CategoryService.getAll();
            return View(ProductService.getProductById(id));
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var pro = ProductService.getProductById(id);
            try
            {
                ProductService.deleteProduct(pro.ProductId);
                string filePath = _hostingEnvironment.WebRootPath + "/admin/img/" + id + "_main_img.jpg";
                System.IO.File.Delete(filePath);
                filePath = _hostingEnvironment.WebRootPath + "/admin/img/" + id + "_img_1.jpg";
                System.IO.File.Delete(filePath);
                filePath = _hostingEnvironment.WebRootPath + "/admin/img/" + id + "_img_2.jpg";
                System.IO.File.Delete(filePath);
                filePath = _hostingEnvironment.WebRootPath + "/admin/img/" + id + "_img_3.jpg";
                System.IO.File.Delete(filePath);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(pro);
            }
        }
    }
}
