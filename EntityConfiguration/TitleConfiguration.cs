using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EntityCodeFirst.Entities;

namespace EntityCodeFirst.EntityConfiguration
{
    public class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.ToTable("Title").HasKey(p => p.TitleId);
            builder.Property(p => p.TitleId).HasColumnName("TitleId");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.HasData(new List<Title>()
            {
                new Title()
                {
                    TitleId = 1, Name = "JuniorDev"
                },
                new Title()
                {
                    TitleId = 2, Name = "MiddleDev"
                },
                new Title()
                {
                    TitleId = 3, Name = "SeniorDev"
                }
            });
        }
    }
}
