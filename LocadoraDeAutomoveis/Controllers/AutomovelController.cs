using AutoMapper;
using LocadoraDeAutomoveis.Aplicacao;
using LocadoraDeAutomoveis.Aplicacao.Serviços;
using LocadoraDeAutomoveis.WebApp.Controllers.Compartilhado;
using Microsoft.AspNetCore.Mvc;

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
			return View();
		}
	}
}
