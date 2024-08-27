using FluentResults;
using LocadoraDeAutomoveis.WebApp.Models;
using LocadoraDeCarros.WebApp.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeAutomoveis.WebApp.Controllers.Compartilhado
{
	public abstract class WebControllerBase : Controller
	{
		protected IActionResult MensagemRegistroNaoEncontrado(int idRegistro)
		{
			TempData.SerializarMensagemViewModel(new MensagemViewModel
			{
				Titulo = "Erro",
				Mensagem = $"Não foi possível encontrar o registro ID [{idRegistro}]!"
			});

			return RedirectToAction("Index", "Home");
		}

		public void ApresentarMensagemFalha(Result resultado)
		{
			ViewBag.Mensagem = new MensagemViewModel
			{
				Titulo = "Falha",
				Mensagem = resultado.Errors[0].Message
			};
		}

		protected void ApresentarMensagemSucesso(string mensagem)
		{
			TempData.SerializarMensagemViewModel(new MensagemViewModel
			{
				Titulo = "Sucesso",
				Mensagem = mensagem
			});
		}
	}
}
