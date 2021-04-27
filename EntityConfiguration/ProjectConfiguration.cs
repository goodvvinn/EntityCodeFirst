using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EntityCodeFirst.Entities;

namespace EntityCodeFirst.EntityConfiguration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project").HasKey(p => p.ProjectId);
            builder.Property(p => p.ProjectId).HasColumnName("ProjectId");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Budget).IsRequired().HasColumnType("money").HasColumnName("Budget");
            builder.Property(p => p.StartedDate).IsRequired().HasColumnType("datetime2").HasMaxLength(7);
            builder.HasOne(p => p.Client)
                    .WithMany(c => c.Project)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
