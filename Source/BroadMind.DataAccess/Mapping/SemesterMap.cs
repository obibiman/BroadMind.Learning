using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using BroadMind.Common.Domain;

namespace BroadMind.DataAccess.Mapping
{
    public class SemesterMap : EntityTypeConfiguration<Semester>
    {
        public SemesterMap()
        {
            ToTable("Semester");
            HasKey(t => t.SemesterId);
            Property(t => t.SemesterId)
                .IsRequired()
                .HasColumnName("SemesterId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasColumnOrder(0)
                .HasColumnType("INT");
            Property(t => t.AcademicYear)
                .IsRequired()
                .HasColumnName("AcademicYear")
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Semester_AcademicYearCalendarYearSemesterNameStudentId", 0)
                        {
                            IsUnique = true
                        }))
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(1)
                .HasMaxLength(20);
            Property(t => t.CalendarYear)
                .IsRequired()
                .HasColumnName("CalendarYear")
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Semester_AcademicYearCalendarYearSemesterNameStudentId", 1)
                        {
                            IsUnique = true
                        }))
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(2)
                .HasMaxLength(20);
            Property(t => t.SemesterName)
                .IsRequired()
                .HasColumnName("SemesterName")
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Semester_AcademicYearCalendarYearSemesterNameStudentId", 2)
                        {
                            IsUnique = true
                        }))
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(3)
                .HasMaxLength(10);
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
            Property(t => t.StudentId)
                .IsRequired()
                .HasColumnName("StudentId")
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Semester_AcademicYearCalendarYearSemesterNameStudentId", 3)
                        {
                            IsUnique = true
                        }))
                .HasColumnType("INT")
                .HasColumnOrder(7);
        }
    }
}