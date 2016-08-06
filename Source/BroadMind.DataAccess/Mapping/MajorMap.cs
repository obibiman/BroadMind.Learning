using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using BroadMind.Common.Domain.Admin;

namespace BroadMind.DataAccess.Mapping
{
    public class MajorMap : EntityTypeConfiguration<Major>
    {
        public MajorMap()
        {
            ToTable("Major");
            HasKey(t => t.MajorId);
            Property(t => t.MajorId)
                .IsRequired()
                .HasColumnName("MajorId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasColumnOrder(0)
                .HasColumnType("INT");
            Property(t => t.MajorName)
                .IsRequired()
                .HasColumnName("MajorName")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(1)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Major_MajorName", 1) {IsUnique = true}))
                .HasMaxLength(50);
            Property(t => t.MajorDescription)
                .IsRequired()
                .HasColumnName("MajorDescription")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(2)
                .HasMaxLength(200);
            Property(t => t.CreatedDate)
                .IsRequired()
                .HasColumnName("CreatedDate")
                .HasColumnOrder(3)
                .HasColumnType("DateTime");
            Property(t => t.ModifiedDate)
                .IsOptional()
                .HasColumnName("ModifiedDate")
                .HasColumnOrder(4)
                .HasColumnType("DateTime");
            Property(t => t.ModifiedBy)
                .IsOptional()
                .HasColumnName("ModifiedBy")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(5)
                .HasMaxLength(50);
        }
    }
}