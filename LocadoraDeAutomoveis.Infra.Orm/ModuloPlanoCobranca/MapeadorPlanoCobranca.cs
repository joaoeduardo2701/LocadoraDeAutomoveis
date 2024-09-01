

using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobranca : IEntityTypeConfiguration<PlanoCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoCobranca> builder)
        {
            builder.ToTable("TBPlanoCobranca");

            builder.Property(p => p.Id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.PrecoDiarioPlanoDiario)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.PrecoQuilometroPlanoDiario)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.QuilometrosDisponiveisPlanoControlado)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.PrecoDiarioPlanoControlado)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.PrecoQuilometroExtrapoladoPlanoControlado)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.PrecoDiarioPlanoLivre)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.GrupoVeiculosId)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(p => p.GrupoAutomoveis)
                .WithMany()
                .HasForeignKey(p => p.GrupoVeiculosId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
