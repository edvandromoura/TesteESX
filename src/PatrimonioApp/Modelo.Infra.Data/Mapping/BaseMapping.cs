using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Modelo.Infra.Data.Mapping
{
    public static class BaseMapping
    {
        public static void CreateDefaultProperties(this EntityTypeBuilder builder)
        {
            builder.Property("Created").HasColumnName("Created").IsRequired();
            builder.Property("Updated").HasColumnName("Updated");
            builder.Property("Ativo").HasColumnName("Ativo").HasDefaultValue(true).HasDefaultValueSql("1").IsRequired();
        }
    }
}
