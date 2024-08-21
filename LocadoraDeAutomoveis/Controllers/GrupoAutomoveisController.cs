using LocadoraDeAutomoveis.Dominio.Compartilhado;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApp.Controllers
{
    public class GrupoAutomoveisController : Controller
    {
	    private readonly IRepositorio<GrupoAutomoveis> repositorioGrupoAutomoveis;
		public IActionResult Listar()
        {
            var grupos = repositorioGrupoAutomoveis.SelecionarTodos();

            var listaGrupos = grupos
                .Select(f => new ListarGrupoAutomoveisViewModel
                {
                    Id = f.Id,
                    Nome = f.Nome
                });

			return View(listaGrupos);
        }
    }
}
