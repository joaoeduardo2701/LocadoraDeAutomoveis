using FluentResults;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraDeAutomoveis.Aplicaco
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
            var genero = repositorioGrupoAutomoveis.SelecionarPorId(grupoAutomoveis.Id);

            if (genero is null)
                return Result.Fail("O genero não foi encontrado!");

            genero.Nome = grupoAutomoveis.Nome;

            repositorioGrupoAutomoveis.Editar(genero);

            return Result.Ok(genero);
        }

        public Result Excluir(int generoId)
        {
            var genero = repositorioGrupoAutomoveis.SelecionarPorId(generoId);

            if (genero is null)
                return Result.Fail("O genero não foi encontrado!");

            repositorioGrupoAutomoveis.Excluir(genero);

            return Result.Ok();
        }

        public Result<GrupoAutomoveis> SelecionarPorId(int generoId)
        {
            var genero = repositorioGrupoAutomoveis.SelecionarPorId(generoId);

            if (genero is null)
                return Result.Fail("O genero não foi encontrado!");

            return Result.Ok(genero);
        }

        public Result<List<GrupoAutomoveis>> SelecionarTodos(int usuarioId)
        {
            var generos = repositorioGrupoAutomoveis
                .Filtrar(f => f.UsuarioId == usuarioId);

            return Result.Ok(generos);
        }
    }
}
