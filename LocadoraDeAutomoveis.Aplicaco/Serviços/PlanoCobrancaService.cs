using FluentResults;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;

namespace LocadoraDeAutomoveis.Aplicacao.Serviços
{
    public class PlanoCobrancaService
    {
        private readonly IRepositorioPlanoCobranca repositorioPlanoCobranca;

        public PlanoCobrancaService(IRepositorioPlanoCobranca repositorioPlanoCobranca)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
        }

        public Result<PlanoCobranca> Inserir(PlanoCobranca planoCobranca)
        {
            repositorioPlanoCobranca.Inserir(planoCobranca);

            return Result.Ok(planoCobranca);
        }

        public Result<PlanoCobranca> Editar(PlanoCobranca planoCobrancaAtualizado)
        {
            var planoCobranca = repositorioPlanoCobranca.SelecionarPorId(planoCobrancaAtualizado.Id);

            if (planoCobranca is null)
                return Result.Fail("O plano de cobrança não foi encontrado!");

            planoCobranca.GrupoVeiculosId = planoCobrancaAtualizado.GrupoVeiculosId;
            planoCobranca.PrecoDiarioPlanoDiario = planoCobrancaAtualizado.PrecoDiarioPlanoDiario;
            planoCobranca.PrecoQuilometroPlanoDiario = planoCobrancaAtualizado.PrecoQuilometroPlanoDiario;
            planoCobranca.QuilometrosDisponiveisPlanoControlado = planoCobrancaAtualizado.QuilometrosDisponiveisPlanoControlado;
            planoCobranca.PrecoDiarioPlanoControlado = planoCobrancaAtualizado.PrecoDiarioPlanoControlado;
            planoCobranca.PrecoQuilometroExtrapoladoPlanoControlado = planoCobrancaAtualizado.PrecoQuilometroExtrapoladoPlanoControlado;
            planoCobranca.PrecoDiarioPlanoLivre = planoCobrancaAtualizado.PrecoDiarioPlanoLivre;

            repositorioPlanoCobranca.Editar(planoCobranca);

            return Result.Ok(planoCobranca);
        }

        public Result<PlanoCobranca> Excluir(int planoCobrancaId)
        {
            var planoCobranca = repositorioPlanoCobranca.SelecionarPorId(planoCobrancaId);

            if (planoCobranca is null)
                return Result.Fail("O plano de cobrança não foi encontrado!");

            repositorioPlanoCobranca.Excluir(planoCobranca);

            return Result.Ok(planoCobranca);
        }

        public Result<PlanoCobranca> SelecionarPorId(int planoCobrancaId)
        {
            var planoCobranca = repositorioPlanoCobranca.SelecionarPorId(planoCobrancaId);

            if (planoCobranca is null)
                return Result.Fail("O plano de cobrança não foi encontrado!");

            return Result.Ok(planoCobranca);
        }

        public Result<List<PlanoCobranca>> SelecionarTodos()
        {
            var planosCobranca = repositorioPlanoCobranca.SelecionarTodos();

            return Result.Ok(planosCobranca);
        }
    }
}
