using AutoMapper;
using LocadoraDeAutomoveis.Aplicacao;
using LocadoraDeAutomoveis.WebApp.Controllers.Compartilhado;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeAutomoveis.WebApp.Models;
using LocadoraDeCarros.WebApp.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApp.Controllers
{
    public class GrupoAutomoveisController : WebControllerBase
    {
		private readonly GrupoAutomoveisService _grupoAutomoveisService;
		private readonly IMapper _mapper;

		public GrupoAutomoveisController(GrupoAutomoveisService grupoAutomoveisService, IMapper mapper)
		{
			_grupoAutomoveisService = grupoAutomoveisService;
			_mapper = mapper;
		}

		public IActionResult Listar()
        {
			var resultado = _grupoAutomoveisService.SelecionarTodos();

			if (resultado.IsFailed) 
			{
				ApresentarMensagemFalha(resultado.ToResult());

				return RedirectToAction("Index", "Home");
			}

			var listaGrupos = resultado.Value;

			var listarGruposVm = _mapper.Map<IEnumerable<ListarGrupoAutomoveisViewModel>>(listaGrupos);

			ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();

			return View(listarGruposVm);
		}

		public IActionResult Inserir()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Inserir(InserirGrupoAutomoveisViewModel inserirVm)
		{
			if (!ModelState.IsValid)
				return View(inserirVm);

			var novoGrupo = _mapper.Map<GrupoAutomoveis>(inserirVm);

			var resultado = _grupoAutomoveisService.Inserir(novoGrupo);

			if (resultado.IsFailed)
			{
				ApresentarMensagemFalha(resultado.ToResult());

				return RedirectToAction(nameof(Listar));
			}

			ApresentarMensagemSucesso($"O registro ID [{novoGrupo.Id}] foi inserido com sucesso!");

			return RedirectToAction(nameof(Listar));
		}

		public IActionResult Editar(int id)
		{
			var resultado = _grupoAutomoveisService.SelecionarPorId(id);

			if (resultado.IsFailed)
			{
				ApresentarMensagemFalha(resultado.ToResult());

				return RedirectToAction(nameof(Listar));
			}

			var grupo = resultado.Value;

			var editarVm = _mapper.Map<EditarGrupoAutomoveisViewModel>(grupo);

			return View("Editar");
		}

		[HttpPost]
		public IActionResult Editar(EditarGrupoAutomoveisViewModel editarVm)
		{
			if (!ModelState.IsValid)
				return View(editarVm);

			var novoGrupo = _mapper.Map<GrupoAutomoveis>(editarVm);

			var resultado = _grupoAutomoveisService.Editar(novoGrupo);

			if (resultado.IsFailed)
			{
				ApresentarMensagemFalha(resultado.ToResult());

				return RedirectToAction(nameof(Listar));
			}

			ApresentarMensagemSucesso($"O registro ID [{novoGrupo.Id}] foi editado com sucesso!");

			return RedirectToAction(nameof(Listar));
		}

		public IActionResult Excluir(int id)
		{
			var resultado = _grupoAutomoveisService.SelecionarPorId(id);

			if (resultado.IsFailed)
			{
				ApresentarMensagemFalha(resultado.ToResult());

				return RedirectToAction(nameof(Listar));
			}

			var grupo = resultado.Value;

			var detalhesVm = _mapper.Map<DetalhesGrupoAutomoveisViewModel>(grupo);

			return View(detalhesVm);
		}

		[HttpPost]
		public IActionResult Excluir(DetalhesGrupoAutomoveisViewModel detalhesVm)
		{
			var resultado = _grupoAutomoveisService.Excluir(detalhesVm.Id);

			if (resultado.IsFailed)
			{
				ApresentarMensagemFalha(resultado);

				return RedirectToAction(nameof(Listar));
			}

			ApresentarMensagemSucesso($"O registro ID [{detalhesVm.Id}] foi excluído com sucesso!");

			return RedirectToAction(nameof(Listar));
		}

		public IActionResult Detalhes(int id)
		{
			var resultado = _grupoAutomoveisService.SelecionarPorId(id);

			if (resultado.IsFailed)
			{
				ApresentarMensagemFalha(resultado.ToResult());

				return RedirectToAction(nameof(Listar));
			}

			var grupo = resultado.Value;

			var detalhesVm = _mapper.Map<DetalhesGrupoAutomoveisViewModel>(grupo);

			return View(detalhesVm);
		}
	}
}
	