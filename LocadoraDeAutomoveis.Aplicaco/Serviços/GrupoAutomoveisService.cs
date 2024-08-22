using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomoveis;
using FluentResults;

namespace LocadoraDeAutomoveis.Aplicacao
{
    public class GrupoAutomoveisService
    {
        private readonly IRepositorioGrupoAutomoveis _repositorioGrupoAutomoveis;

        public GrupoAutomoveisService(IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis)
        {
            _repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
        }

        public Result<GrupoAutomoveis> Inserir(GrupoAutomoveis grupoAutomoveis)
        {
            _repositorioGrupoAutomoveis.Inserir(grupoAutomoveis);

            return Result.Ok(grupoAutomoveis);
        }

        public Result<GrupoAutomoveis> Editar(GrupoAutomoveis grupoAutomoveis)
        {
            var grupo = _repositorioGrupoAutomoveis.SelecionarPorId(grupoAutomoveis.Id);

            if (grupo is null)
                return Result.Fail("O grupo não foi encontrado!");

            grupo.Nome = grupoAutomoveis.Nome;

            _repositorioGrupoAutomoveis.Editar(grupo);

            return Result.Ok(grupo);
        }

        public Result Excluir(int generoId)
        {
            var grupo = _repositorioGrupoAutomoveis.SelecionarPorId(generoId);

            if (grupo is null)
                return Result.Fail("O grupo não foi encontrado!");

            _repositorioGrupoAutomoveis.Excluir(grupo);

            return Result.Ok();
        }

        public Result<GrupoAutomoveis> SelecionarPorId(int grupoId)
        {
            var grupo = _repositorioGrupoAutomoveis.SelecionarPorId(grupoId);

            if (grupo is null)
                return Result.Fail("O grupo não foi encontrado!");

            return Result.Ok(grupo);
        }   

        public Result<List<GrupoAutomoveis>> SelecionarTodos()
        {
	        var grupos = _repositorioGrupoAutomoveis.SelecionarTodos();

	        return Result.Ok(grupos);
		}
    }
}
