using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using BroadMind.Common.Domain.Admin;

namespace BroadMind.DataAccess.Mapping
{
    public class StateMap : EntityTypeConfiguration<State>
    {
        public StateMap()
        {
            ToTable("State");
            HasKey(t => t.StateId);
            Property(t => t.StateId)
                .IsRequired()
                .HasColumnName("StateId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasColumnOrder(0)
                .HasColumnType("INT");
            Property(t => t.StateCode)
                .IsRequired()
                .HasColumnName("StateCode")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(1)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_State_StateCodeStateName", 1) {IsUnique = true}))
                .HasMaxLength(10);
            Property(t => t.StateName)
                .IsRequired()
                .HasColumnName("StateName")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(2)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_State_StateCodeStateName", 2) {IsUnique = true}))
                .HasMaxLength(50);
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