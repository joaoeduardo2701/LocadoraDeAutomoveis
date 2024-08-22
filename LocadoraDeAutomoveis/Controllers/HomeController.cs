using Microsoft.AspNetCore.Mvc;


namespace LocadoraDeAutomoveis.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
