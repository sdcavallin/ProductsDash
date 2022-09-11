using FirstWebAppMVC.Models;
using FirstWebAppMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAppMVC.Controllers
{
    public class CardsController : Controller
    {
        public IActionResult Index()
        {
            CardDataService service = new CardDataService();

            return View(service.GetAllCards());
        }

    }
}
