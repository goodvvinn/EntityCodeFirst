using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EntityCodeFirst.Entities;

namespace EntityCodeFirst.EntityConfiguration
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Office").HasKey(p => p.OfficeId);
            builder.Property(p => p.OfficeId).HasColumnName("OfficeId");
            builder.Property(p => p.Title).IsRequired().HasColumnName("Title").HasMaxLength(100);
            builder.Property(p => p.Location).IsRequired().HasColumnName("Location").HasMaxLength(100);
            builder.HasData(new List<Office>()
             {
                new Office()
                {
                    OfficeId = 1, Location = "Sydney", Title = "WestOffice"
                },
                new Office()
                {
                    OfficeId = 2, Location = "Canberra", Title = "ShoreOffice"
                }
             });
        }
    }
}
