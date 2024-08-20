using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.Controllers
{
    public class GrupoAutomoveisController : Controller
    {
        public IActionResult Listar()
        {
            return View();
        }
    }
}
