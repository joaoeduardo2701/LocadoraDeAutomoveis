using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;
using LocadoraDeAutomoveis.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloAutomovel
{
	public class RepositorioAutomovelEmOrm : RepositorioBaseEmOrm<Automovel>, IRepositorioAutomovel
	{
		public RepositorioAutomovelEmOrm(LocadoraDeAutomoveisDbContext dbContext) : base(dbContext)
		{
		}

		protected override DbSet<Automovel> ObterRegistros()
		{
			return _dbContext.Automoveis;
		}

		public override Automovel? SelecionarPorId(int id)
		{
			return ObterRegistros()
				.Include(v => v.GrupoAutomoveis)
				.FirstOrDefault(v  => v.Id == id);
		}

		public override List<Automovel> SelecionarTodos()
		{
			return ObterRegistros().Include(v => v.GrupoAutomoveis).ToList();
		}
	}
}
