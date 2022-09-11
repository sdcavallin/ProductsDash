using Bogus;
using FirstWebAppMVC.Models;
using FirstWebAppMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAppMVC.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            IProductDataService productService = new ProductsDAO();

            return View(productService.GetAllProducts());
        }

        public IActionResult CreateForm()
        {
            return View();
        }

        public IActionResult CreateResults(ProductModel product)
        {
            IProductDataService productService = new ProductsDAO();

            return Details(productService.Insert(product));
        }

        public IActionResult Details(int id)
        {
            IProductDataService productService = new ProductsDAO();

            return View("Details", productService.GetProductById(id));
        }

        public IActionResult SearchResults(string query)
        {
            IProductDataService productService = new ProductsDAO();
            
            List<ProductModel> list = productService.Search(query);

            return View("Index", list);
        }

        public IActionResult SearchForm()
        {
            return View();
        }
    }
}
