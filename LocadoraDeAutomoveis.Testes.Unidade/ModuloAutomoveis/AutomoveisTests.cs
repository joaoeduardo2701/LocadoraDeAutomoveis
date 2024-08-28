using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;

namespace LocadoraDeAutomoveis.Testes.Unidade.ModuloAutomoveis
{
	[TestClass]
	[TestCategory("Unidade")]
	internal class AutomoveisTests
	{
		public void Deve_Criar_Instancia_Valida()
		{
			var automovel = new Automovel
			(
				"Modelo A",
				"Marca X",
				TipoCombustivel.Gasolina,
				50,
				1
			);

			var erros = automovel.Validar();

			Assert.AreEqual(0, erros.Count);
		}

		[TestMethod]
		public void Deve_Criar_Instancia_Com_Erro()
		{
			var automovel = new Automovel
			(
				"",
				"",
				TipoCombustivel.Gasolina,
				0,
				0
			);

			var erros = automovel.Validar();

			List<string> errosEsperados =
			[
				"O modelo é obrigatório",
				"A marca é obrigatória",
				"A capacidade do tanque precisa ser informada",
				"O grupo de veículos é obrigatório"
			];

			Assert.AreEqual(errosEsperados.Count, erros.Count);
			CollectionAssert.AreEqual(errosEsperados, erros);
		}

	}
}
