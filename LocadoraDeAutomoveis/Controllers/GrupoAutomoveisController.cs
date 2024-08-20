using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApp.Controllers
{
    public class GrupoAutomoveisController : Controller
    {
        public IActionResult Listar()
        {
            return View();
        }
    }
}
