using LocadoraDeAutomoveis.WebApp.Controllers.Compartilhado;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApp.Controllers
{
    public class PlanoCobrancaController : WebControllerBase
    {
        public IActionResult Listar()
        {
            return View();
        }
    }
}
