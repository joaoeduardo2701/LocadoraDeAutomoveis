using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraDeAutomoveis.Infra.Orm.GrupoAutomoveis
{
    public class MapeadorGrupoAutomoveisConfiguration : IEntityTypeConfiguration<Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis>
    {
        public void Configure(EntityTypeBuilder<Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis> builder)
        {
            builder.ToTable("TBGrupoAutomoveis");

            builder.Property(f => f.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(f => f.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");
        }
    }
}
