using LocadoraDeAutomoveis.Dominio.Compartilhado;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraDeAutomoveis.Dominio.ModuloAutomovel
{
	public class Automovel : EntidadeBase
	{
		public string Modelo { get; set; }
		public string Marca { get; set; }
		public TipoCombustivel TipoCombustivel { get; set; }
		public int CapacidadeTanque { get; set; }
		public int GrupoAutomoveisId { get; set; }
		public GrupoAutomoveis? GrupoAutomoveis { get; set; }

        protected Automovel() { }

        public Automovel(
	        string modelo,
	        string marca,
	        TipoCombustivel tipoCombustivel,
	        int capacidadeTanque,
	        int grupoAutomoveisId
		)
        {
	        Modelo = modelo;
	        Marca = marca;
	        TipoCombustivel = tipoCombustivel;
	        CapacidadeTanque = capacidadeTanque;
			GrupoAutomoveisId = grupoAutomoveisId;
        }

		public override List<string> Validar()
		{
			List<string> erros = [];

			if (string.IsNullOrEmpty(Modelo))
				erros.Add("O modelo é obrigatório");

			if (string.IsNullOrEmpty(Marca))
				erros.Add("A marca é obrigatória");

			if (CapacidadeTanque == 0)
				erros.Add("A capacidade do tanque precisa ser informada");

			if (GrupoAutomoveisId == 0)
				erros.Add("O grupo de veículos é obrigatório");

			return erros;
		}
	}
}
