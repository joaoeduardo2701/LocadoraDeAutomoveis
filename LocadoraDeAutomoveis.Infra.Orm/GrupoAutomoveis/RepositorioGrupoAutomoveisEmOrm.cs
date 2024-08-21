using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeAutomoveis.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.Infra.Orm.GrupoAutomoveis
{
    public class RepositorioGrupoAutomoveisEmOrm : 
        RepositorioBaseEmOrm<Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis>, IRepositorioGrupoAutomoveis
    {
        public RepositorioGrupoAutomoveisEmOrm(LocadoraDeAutomoveisDbContext dbContext) : base(dbContext) { }

        protected override DbSet<Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis> ObterRegistros()
        {
            return _dbContext.GrupoAutomoveis;
        }

        public List<Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis> Filtrar(Func<Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis, bool> predicate)
        {
            return _dbContext.GrupoAutomoveis
                .Where(predicate)
                .ToList();
        }
    }
}
