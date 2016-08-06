using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using BroadMind.Common.Domain.Admin;

namespace BroadMind.DataAccess.Mapping
{
    public class CourseMap : EntityTypeConfiguration<Course>
    {
        public CourseMap()
        {
            ToTable("Course");
            HasKey(t => t.CourseId);
            Property(t => t.CourseId)
                .IsRequired()
                .HasColumnName("CourseId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasColumnOrder(0)
                .HasColumnType("INT");
            Property(t => t.CourseName)
                .IsRequired()
                .HasColumnName("CourseName")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(1)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Course_CourseName", 1) {IsUnique = true}))
                .HasMaxLength(50);
            Property(t => t.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(2)
                .HasMaxLength(250);
            Property(t => t.Credit)
                .IsOptional()
                .HasColumnName("Credit")
                .HasColumnOrder(3)
                .HasColumnType("INT");
            Property(t => t.CreatedDate)
                .IsRequired()
                .HasColumnName("CreatedDate")
                .HasColumnOrder(4)
                .HasColumnType("DateTime");
            Property(t => t.ModifiedDate)
                .IsOptional()
                .HasColumnName("ModifiedDate")
                .HasColumnOrder(5)
                .HasColumnType("DateTime");
            Property(t => t.ModifiedBy)
                .IsOptional()
                .HasColumnName("ModifiedBy")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(6)
                .HasMaxLength(50);
            HasMany(t => t.Students);
            HasRequired(t => t.Department);
        }
    }
}