using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloAutomovel
{
	public class MapeadorAutomovelConfiguration : IEntityTypeConfiguration<Automovel>
	{
		public void Configure(EntityTypeBuilder<Automovel> builder)
		{
			builder.ToTable("TBAutomovel");

			builder.Property(v => v.Id)
				.HasColumnType("int")
				.ValueGeneratedOnAdd()
				.IsRequired();

			builder.Property(v => v.Modelo)
				.HasColumnType("varchar(100)")
				.IsRequired();

			builder.Property(v => v.Marca)
				.HasColumnType("varchar(100)")
				.IsRequired();

			builder.Property(v => v.TipoCombustivel)
				.HasColumnType("int")
				.IsRequired();

			builder.Property(v => v.CapacidadeTanque)
				.HasColumnType("int")
				.IsRequired();

			builder.Property(v => v.GrupoAutomoveisId)
				.HasColumnType("int")
				.IsRequired();

			builder.HasOne(v => v.GrupoAutomoveis)
				.WithMany(g => g.Automoveis)
				.HasForeignKey(v => v.GrupoAutomoveisId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
