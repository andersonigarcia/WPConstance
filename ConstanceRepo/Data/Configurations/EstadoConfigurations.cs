using ConstanceRepo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConstanceRepo.Data.Configurations
{
    public class EstadoConfigurations : IEntityTypeConfiguration<Estado>
    {
        void IEntityTypeConfiguration<Estado>.Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.Property(P => P.Ativo).HasDefaultValue(true).ValueGeneratedOnAdd();
            builder.Property(P => P.AddedDate).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(P => P.ModifiedDate).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(40)").IsRequired();
            builder.Property(p => p.Sigla).HasColumnType("CHAR(2)").IsRequired();

        }
    }
}
