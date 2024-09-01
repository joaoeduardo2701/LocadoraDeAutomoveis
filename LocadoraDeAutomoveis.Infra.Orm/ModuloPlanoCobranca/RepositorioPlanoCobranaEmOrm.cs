using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraDeAutomoveis.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloPlanoCobranca
{
    public class RepositorioPlanoCobranaEmOrm : RepositorioBaseEmOrm<PlanoCobranca>, IRepositorioPlanoCobranca
    {
        public RepositorioPlanoCobranaEmOrm(LocadoraDeAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<PlanoCobranca> ObterRegistros()
        {
            return _dbContext.PlanosCobranca;
        }

        public override PlanoCobranca? SelecionarPorId(int id)
        {
            return ObterRegistros()
                .Include(p => p.GrupoAutomoveis)
                .FirstOrDefault(p => p.Id == id);
        }

        public override List<PlanoCobranca> SelecionarTodos()
        {
            return ObterRegistros()
                .Include(p => p.GrupoAutomoveis)
                .AsNoTracking()
                .ToList();
        }
    }
}
