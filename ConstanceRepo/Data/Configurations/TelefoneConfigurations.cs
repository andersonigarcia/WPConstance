using ConstanceRepo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConstanceRepo.Data.Configurations
{
    public class TelefoneConfigurations : IEntityTypeConfiguration<Telefone>
    {
        void IEntityTypeConfiguration<Telefone>.Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.Property(P => P.Ativo).HasDefaultValue(true).ValueGeneratedOnAdd();
            builder.Property(P => P.AddedDate).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(P => P.ModifiedDate).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();
            builder.Property(p => p.Numero).HasMaxLength(11).IsRequired();
            builder.Property(p => p.Tipo).HasConversion<string>();
        }
    }
}
