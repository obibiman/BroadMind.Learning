using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BroadMind.Common.Domain;

namespace BroadMind.DataAccess.Mapping
{
    public class EnrollmentMap : EntityTypeConfiguration<Enrollment>
    {
        public EnrollmentMap()
        {
            ToTable("Enrollment");
            HasKey(t => t.EnrollmentId);
            Property(t => t.EnrollmentId)
                .IsRequired()
                .HasColumnName("EnrollmentId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasColumnOrder(0)
                .HasColumnType("INT");
            Property(t => t.CreatedDate)
                .IsRequired()
                .HasColumnName("CreatedDate")
                .HasColumnOrder(1)
                .HasColumnType("DateTime");
            Property(t => t.ModifiedDate)
                .IsOptional()
                .HasColumnName("ModifiedDate")
                .HasColumnOrder(2)
                .HasColumnType("DateTime");
            Property(t => t.ModifiedBy)
                .IsOptional()
                .HasColumnName("ModifiedBy")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(3)
                .HasMaxLength(50);
            //Property(t => t.CourseId)
            //    .IsOptional()
            //    .HasColumnName("CourseId")
            //    .HasColumnOrder(4)
            //    .HasColumnType("INT");
            HasMany(t => t.Students);
        }
    }
}