using Microsoft.AspNetCore.Mvc;
using Web_Application.IServices;
using Web_Application.Models;
using Web_Application.Services;
using System.Collections.Generic;
using System.Linq;
using System.IO;
namespace Web_Application.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductServices _productsServices;

        public ProductsController()
        {
            _productsServices = new ProductServices();
        }
        public IActionResult Categories()
        {
            var products = _productsServices.GetAllProducts();
            return View(products);
        }
        public IActionResult ShowListProduct()
        {
            var products = _productsServices.GetAllProducts();
            return View(products);
        }

        public IActionResult DeleteProduct(Guid id)
        {
            _productsServices.DeleteProduct(id);
            return RedirectToAction("ShowListProduct");
        }
        //
        public int lastPrice = 0;
        [HttpGet]
        public IActionResult EditProduct(Guid id)
        {
            var product = _productsServices.GetProductById(id);
            lastPrice = product.Price;
            return View(product);
        }
        public IActionResult EditProduct(Product product)
        {
            if (product.AvailableQuantity > 0 && product.Description != null)
            {
                if (product.Price > lastPrice)
                {
                    _productsServices.UpdateProduct(product);
                    return RedirectToAction("ShowListProduct");
                }
                else
                {
                    return Content("Price more than 0");
                }
            }
            else
            {
                return Content("Quantity < 0 hoac Description null");
            }
        }
        //
        public IActionResult DetailsProduct(Guid id)
        {
            var product = _productsServices.GetProductById(id);
            return View(product);
        }
        //
        public IActionResult CreateNewProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNewProduct(Product product)
        {
            _productsServices.CreateNewProducts(product);
            return RedirectToAction("ShowListProduct");
        }
        public IActionResult CategoriesDetails(Guid id)
        {
            var product = _productsServices.GetProductById(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult GetProductsByName(string name)
        {
            var p = _productsServices.GetProductByName(name);
            return View("Categories", p.ToList());
        }
    }
}
