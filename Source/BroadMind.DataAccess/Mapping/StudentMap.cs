using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BroadMind.Common.Domain;

namespace BroadMind.DataAccess.Mapping
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            ToTable("Student");
            HasKey(t => t.StudentId);
            Property(t => t.StudentId)
                .IsRequired()
                .HasColumnName("StudentId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasColumnOrder(0)
                .HasColumnType("INT");
            Property(t => t.FirstName)
                .IsRequired()
                .HasColumnName("FirstName")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(1)
                .HasMaxLength(50);
            Property(t => t.MiddleName)
                .IsRequired()
                .HasColumnName("MiddleName")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(2)
                .HasMaxLength(50);
            Property(t => t.LastName)
                .IsRequired()
                .HasColumnName("LastName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);
            Property(t => t.Gender)
                .IsOptional()
                .HasColumnName("Gender")
                .HasColumnOrder(3)
                .HasColumnType("INT");
            Property(t => t.AccruedCredit)
                .IsOptional()
                .HasColumnName("AccruedCredit")
                .HasColumnOrder(4)
                .HasColumnType("INT");
            Property(t => t.InitialEnrollmentDate)
                .IsRequired()
                .HasColumnName("InitialEnrollmentDate")
                .HasColumnOrder(5)
                .HasColumnType("DateTime");
            Property(t => t.DateOfBirth)
                .IsRequired()
                .HasColumnName("DateOfBirth")
                .HasColumnOrder(6)
                .HasColumnType("DateTime");
            Property(t => t.Email)
                .IsOptional()
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(7)
                .HasMaxLength(50);
            Property(t => t.CreatedDate)
                .IsRequired()
                .HasColumnName("CreatedDate")
                .HasColumnOrder(8)
                .HasColumnType("DateTime");
            Property(t => t.ModifiedDate)
                .IsOptional()
                .HasColumnName("ModifiedDate")
                .HasColumnOrder(9)
                .HasColumnType("DateTime");
            Property(t => t.ModifiedBy)
                .IsOptional()
                .HasColumnName("ModifiedBy")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(10)
                .HasMaxLength(50);
            Ignore(p => p.FullName);
            HasMany(t => t.Telephones);
            HasOptional(t => t.Major);
            HasMany(t => t.Enrollments);
            HasMany(t => t.Semesters);
            HasRequired(t => t.Address);
        }
    }
}