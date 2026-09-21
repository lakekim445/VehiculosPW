using Microsoft.AspNetCore.Mvc;

namespace VehiculosMVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}