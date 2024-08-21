using FluentResults;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraDeAutomoveis.Aplicacao
{
    public class GrupoAutomoveisService
    {
        private readonly IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis;

        public GrupoAutomoveisService(IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis)
        {
            this.repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
        }

        public Result<GrupoAutomoveis> Inserir(GrupoAutomoveis grupoAutomoveis)
        {
            repositorioGrupoAutomoveis.Inserir(grupoAutomoveis);

            return Result.Ok(grupoAutomoveis);
        }

        public Result<GrupoAutomoveis> Editar(GrupoAutomoveis grupoAutomoveis)
        {
            var grupo = repositorioGrupoAutomoveis.SelecionarPorId(grupoAutomoveis.Id);

            if (grupo is null)
                return Result.Fail("O grupo não foi encontrado!");

            grupo.Nome = grupoAutomoveis.Nome;

            repositorioGrupoAutomoveis.Editar(grupo);

            return Result.Ok(grupo);
        }

        public Result Excluir(int generoId)
        {
            var grupo = repositorioGrupoAutomoveis.SelecionarPorId(generoId);

            if (grupo is null)
                return Result.Fail("O grupo não foi encontrado!");

            repositorioGrupoAutomoveis.Excluir(grupo);

            return Result.Ok();
        }

        public Result<GrupoAutomoveis> SelecionarPorId(int grupoId)
        {
            var grupo = repositorioGrupoAutomoveis.SelecionarPorId(grupoId);

            if (grupo is null)
                return Result.Fail("O grupo não foi encontrado!");

            return Result.Ok(grupo);
        }   

        public Result<List<GrupoAutomoveis>> SelecionarTodos(int usuarioId)
        {
            var grupos = repositorioGrupoAutomoveis.SelecionarTodos();
            return Result.Ok(grupos);
        }
    }
}
