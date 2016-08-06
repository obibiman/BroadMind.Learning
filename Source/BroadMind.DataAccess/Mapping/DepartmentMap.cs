using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using BroadMind.Common.Domain.Admin;

namespace BroadMind.DataAccess.Mapping
{
    public class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            ToTable("Department");
            HasKey(t => t.DepartmentId);
            Property(t => t.DepartmentId)
                .IsRequired()
                .HasColumnName("DepartmentId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasColumnOrder(0)
                .HasColumnType("INT");
            Property(t => t.DepartmentCode)
                .IsRequired()
                .HasColumnName("DepartmentCode")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(1)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Department_DepartmentCode", 0) {IsUnique = true}))
                .HasMaxLength(10);
            Property(t => t.DepartmentName)
                .IsRequired()
                .HasColumnName("DepartmentName")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(2)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Department_DepartmentName", 1) {IsUnique = true}))
                .HasMaxLength(50);
            Property(t => t.DepartmentDescription)
                .IsRequired()
                .HasColumnName("DepartmentDescription")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(3)
                .HasMaxLength(250);
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
            HasRequired(t => t.Courses);
            HasMany(t => t.Courses);
        }
    }
}