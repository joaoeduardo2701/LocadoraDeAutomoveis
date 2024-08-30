using LocadoraDeAutomoveis.Dominio.Compartilhado;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca
{
    public class PlanoCobranca : EntidadeBase 
    {
        public int GrupoVeiculosId { get; set; }
        public GrupoAutomoveis GrupoAutomoveis { get; set; }

        public decimal PrecoDiarioPlanoDiario { get; set; }
        public decimal PrecoQuilometroPlanoDiario { get; set; }

        public decimal QuilometrosDisponiveisPlanoControlado { get; set; }
        public decimal PrecoDiarioPlanoControlado { get; set; }
        public decimal PrecoQuilometroExtrapoladoPlanoControlado { get; set; }

        public decimal PrecoDiarioPlanoLivre { get; set; }

        public PlanoCobranca(
            int grupoVeiculosId,
            decimal precoDiarioPlanoDiario,
            decimal precoQuilometroPlanoDiario,
            decimal quilometrosDisponiveisPlanoControlado,
            decimal precoDiarioPlanoControlado,
            decimal precoQuilometroExtrapoladoPlanoControlado,
            decimal precoDiarioPlanoLivre
        )
        {
            GrupoVeiculosId = grupoVeiculosId;

            PrecoDiarioPlanoDiario = precoDiarioPlanoDiario;
            PrecoQuilometroPlanoDiario = precoQuilometroPlanoDiario;

            QuilometrosDisponiveisPlanoControlado = quilometrosDisponiveisPlanoControlado;
            PrecoDiarioPlanoControlado = precoDiarioPlanoControlado;
            PrecoQuilometroExtrapoladoPlanoControlado = precoQuilometroExtrapoladoPlanoControlado;

            PrecoDiarioPlanoLivre = precoDiarioPlanoLivre;
        }

        public override List<string> Validar()
        {
            List<string> erros = [];

            if (GrupoVeiculosId == 0)
                erros.Add("O grupo de veículos é obrigatório");

            return erros;
        }
    }
}
