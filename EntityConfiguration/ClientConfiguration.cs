using Microsoft.EntityFrameworkCore;
using EntityCodeFirst.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityCodeFirst.EntityConfiguration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client").HasKey(p => p.ClientId);
            builder.Property(p => p.ClientId).HasColumnName("ClientId");
            builder.Property(p => p.FirstName).IsRequired().HasColumnName("FirstName").HasMaxLength(50);
            builder.Property(p => p.LastName).IsRequired().HasColumnName("LastName").HasMaxLength(50);
            builder.Property(p => p.ContractDate).IsRequired().HasColumnType("datetime").HasColumnName("ContractDate").HasMaxLength(7);
            builder.Property(p => p.CooperationType).IsRequired().HasColumnName("CooperationType").HasMaxLength(50);
        }
    }
}
