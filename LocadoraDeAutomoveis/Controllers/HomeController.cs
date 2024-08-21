using LocadoraDeAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
