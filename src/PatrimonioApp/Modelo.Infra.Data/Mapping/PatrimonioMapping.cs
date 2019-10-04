using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelo.Domain.Entities;

namespace Modelo.Infra.Data.Mapping
{
    public class PatrimonioMapping : IEntityTypeConfiguration<Patrimonio>
    {
        public void Configure(EntityTypeBuilder<Patrimonio> builder)
        {
            builder.ToTable("tbPatrimonio");

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Marca).WithMany().HasConstraintName("FK_Patrimonio_Marca").IsRequired();

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnName("Nome").HasMaxLength(255);

            builder.Property(c => c.Descricao)
                    .IsRequired()
                    .HasColumnName("Descricao");

            builder.Property(c => c.NumeroTombo)
                    .IsRequired()
                    .HasColumnName("NumeroTombo");

            builder.CreateDefaultProperties();
        }
    }
}
