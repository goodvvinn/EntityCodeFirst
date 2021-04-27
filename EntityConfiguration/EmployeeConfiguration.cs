using Microsoft.EntityFrameworkCore;
using EntityCodeFirst.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityCodeFirst.EntityConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee").HasKey(p => p.EmployeeId);
            builder.Property(p => p.EmployeeId).HasColumnName("EmployeeId");
            builder.Property(p => p.FirstName).HasColumnName("FirstName").HasMaxLength(50);
            builder.Property(p => p.LastName).IsRequired().HasColumnName("LastName").HasMaxLength(50);
            builder.Property(p => p.HiredDate).IsRequired().HasColumnName("HiredDate").HasColumnType("datetime2").HasMaxLength(7);
            builder.Property(p => p.DateOfBirth).HasColumnName("DateOfBirth").HasColumnType("date");
            builder.HasOne(d => d.Title)
               .WithMany(c => c.Employee)
               .HasForeignKey(d => d.TitleId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.Office)
               .WithMany(p => p.Employee)
               .HasForeignKey(d => d.OfficeId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
