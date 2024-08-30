using AutoMapper;
using LocadoraDeAutomoveis.Aplicacao;
using LocadoraDeAutomoveis.Aplicacao.Serviços;
using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;
using LocadoraDeAutomoveis.WebApp.Controllers.Compartilhado;
using LocadoraDeAutomoveis.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeAutomoveis.WebApp.Controllers
{
	public class AutomovelController : WebControllerBase
	{
        private readonly AutomovelService servico;
        private readonly GrupoAutomoveisService servicoGrupos;
        private readonly IMapper mapeador;

        public AutomovelController(AutomovelService servico, GrupoAutomoveisService servicoGrupos, IMapper mapeador)
        {
            this.servico = servico;
            this.servicoGrupos = servicoGrupos;
            this.mapeador = mapeador;
        }

        public IActionResult Listar()
		{
            var resultado = servico.SelecionarTodos();

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction("Index", "Home");
            }

            var automoveis = resultado.Value;

            var listarAutomoveisVm = mapeador.Map<IEnumerable<ListarAutomovelViewModel>>(automoveis);


            return View(listarAutomoveisVm);
		}

        public IActionResult Inserir()
        {
            return View(CarregarDadosFormulario());
        }

        [HttpPost]
        public IActionResult Inserir(InserirAutomovelViewModel inserirVm)
        {
            if (!ModelState.IsValid)
                return View(CarregarDadosFormulario(inserirVm));

            var veiculo = mapeador.Map<Automovel>(inserirVm);

            var resultado = servico.Inserir(veiculo);


            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{veiculo.Id}] foi inserido com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Editar(int id)
        {
            var resultado = servico.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var resultadoGrupos = servicoGrupos.SelecionarTodos();

            if (resultadoGrupos.IsFailed)
            {
                ApresentarMensagemFalha(resultadoGrupos.ToResult());

                return null;
            }

            var veiculo = resultado.Value;

            var editarVm = mapeador.Map<EditarAutomovelViewModel>(veiculo);

            var gruposDisponiveis = resultadoGrupos.Value;

            editarVm.GruposAutomoveis = gruposDisponiveis
                .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));

            return View(editarVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarAutomovelViewModel editarVm)
        {
            if (!ModelState.IsValid)
                return View(CarregarDadosFormulario(editarVm));

            var veiculo = mapeador.Map<Automovel>(editarVm);

            var resultado = servico.Editar(veiculo);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{veiculo.Id}] foi editado com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Excluir(int id)
        {
            var resultado = servico.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var veiculo = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesAutomovelViewModel>(veiculo);

            return View(detalhesVm);
        }

        [HttpPost]
        public IActionResult Excluir(DetalhesAutomovelViewModel detalhesVm)
        {
            var resultado = servico.Excluir(detalhesVm.Id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            ApresentarMensagemSucesso($"O registro ID [{detalhesVm.Id}] foi excluído com sucesso!");

            return RedirectToAction(nameof(Listar));
        }

        public IActionResult Detalhes(int id)
        {
            var resultado = servico.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var automovel = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesAutomovelViewModel>(automovel);

            return View(detalhesVm);
        }

        private FormularioAutomovelViewModel? CarregarDadosFormulario(FormularioAutomovelViewModel? dadosPrevios = null)
        {
            var resultadoGrupos = servicoGrupos.SelecionarTodos();

            if (resultadoGrupos.IsFailed)
            {
                ApresentarMensagemFalha(resultadoGrupos.ToResult());

                return null;
            }

            var gruposDisponiveis = resultadoGrupos.Value;

            if (dadosPrevios is null)
            {
                var formularioVm = new FormularioAutomovelViewModel
                {
                    GruposAutomoveis = gruposDisponiveis
                        .Select(g => new SelectListItem(g.Nome, g.Id.ToString()))
                };

                return formularioVm;
            }

            dadosPrevios.GruposAutomoveis = gruposDisponiveis
                .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));

            return dadosPrevios;
        }

    }
}
