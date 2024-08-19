using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.Web.Controllers
{
    public class Funcionario : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
