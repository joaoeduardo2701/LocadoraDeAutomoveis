using AutoMapper;
using LocadoraDeAutomoveis.Aplicacao;
using LocadoraDeAutomoveis.Dominio.Compartilhado;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeAutomoveis.WebApp.Models;
using LocadoraDeCarros.WebApp.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApp.Controllers
{
    public class GrupoAutomoveisController : Controller
    {
		//private readonly IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis;
		//public GrupoAutomoveisController(IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis)
		//{
		//	this.repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
		//}

		private readonly GrupoAutomoveisService _grupoAutomoveisService;
		private readonly IMapper _mapper;

		public GrupoAutomoveisController(GrupoAutomoveisService grupoAutomoveisService, IMapper mapper)
		{
			_grupoAutomoveisService = grupoAutomoveisService;
			_mapper = mapper;
		}

		public IActionResult Listar()
        {
			//var grupos = repositorioGrupoAutomoveis.SelecionarTodos();

			//var listaGrupos = grupos
			//	.Select(f => new ListarGrupoAutomoveisViewModel
			//	{
			//		Id = f.Id,
			//		Nome = f.Nome
			//	});

			//ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();

			//return View(listaGrupos);

			var resultado = _grupoAutomoveisService.SelecionarTodos();

			var listaGrupos = resultado.Value;

			var listarGruposVm = _mapper.Map<IEnumerable<ListarGrupoAutomoveisViewModel>>(listaGrupos);

			ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();

			return View(listarGruposVm);
		}
	}
}
