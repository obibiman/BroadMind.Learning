using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using BroadMind.Common.Domain;

namespace BroadMind.DataAccess.Mapping
{
    public class TelephoneMap : EntityTypeConfiguration<Telephone>
    {
        public TelephoneMap()
        {
            ToTable("Telephone");
            HasKey(t => t.TelephoneId);
            Property(t => t.TelephoneId)
                .IsRequired()
                .HasColumnName("TelephoneId")
                .HasColumnOrder(0)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasColumnType("INT");
            Property(t => t.AreaCode)
                .IsRequired()
                .HasColumnOrder(1)
                .HasColumnName("AreaCode")
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Telephone_AreaCodePrefixLineNumber", 1) {IsUnique = true}))
                .HasColumnType("NVARCHAR")
                .HasMaxLength(3);
            Property(t => t.Prefix)
                .IsRequired()
                .HasColumnOrder(2)
                .HasColumnName("Prefix")
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Telephone_AreaCodePrefixLineNumber", 2) {IsUnique = true}))
                .HasColumnType("NVARCHAR")
                .HasMaxLength(3);
            Property(t => t.LineNumber)
                .IsRequired()
                .HasColumnOrder(3)
                .HasColumnName("LineNumber")
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Telephone_AreaCodePrefixLineNumber", 3) {IsUnique = true}))
                .HasColumnType("NVARCHAR")
                .HasMaxLength(4);
            Property(t => t.Extension)
                .IsOptional()
                .HasColumnOrder(4)
                .HasColumnName("Extension")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(5);
            Property(t => t.PhoneType)
                .IsRequired()
                .HasColumnOrder(5)
                .HasColumnName("PhoneType")
                .HasColumnType("INT");
            Property(t => t.CreatedDate)
                .IsRequired()
                .HasColumnOrder(6)
                .HasColumnName("CreatedDate")
                .HasColumnType("DateTime");
            Property(t => t.ModifiedDate)
                .IsOptional()
                .HasColumnOrder(7)
                .HasColumnName("ModifiedDate")
                .HasColumnType("DateTime");
            Property(t => t.ModifiedBy)
                .IsOptional()
                .HasColumnOrder(8)
                .HasColumnName("ModifiedBy")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);
            Property(t => t.StudentId)
                .IsRequired()
                .HasColumnName("StudentId")
                .HasColumnType("INT")
                .HasColumnOrder(9);
            Ignore(p => p.TelephoneNumber);
        }
    }
}