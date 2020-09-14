using ConstanceRepo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConstanceRepo.Data.Configurations
{
    public class ClienteConfigurations : IEntityTypeConfiguration<Cliente>
    {
        void IEntityTypeConfiguration<Cliente>.Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(P => P.Ativo).HasDefaultValue(true).ValueGeneratedOnAdd();
            builder.Property(P => P.AddedDate).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(P => P.ModifiedDate).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(p => p.CPF).HasColumnType("CHAR(11)").IsRequired();

            builder.HasMany(v => v.Telefone)
                .WithOne(v => v.Cliente)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
