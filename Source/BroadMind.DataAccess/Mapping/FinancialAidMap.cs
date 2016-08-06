using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BroadMind.Common.Domain;

namespace BroadMind.DataAccess.Mapping
{
    public class FinancialAidMap : EntityTypeConfiguration<FinancialAid>
    {
        public FinancialAidMap()
        {
            ToTable("FinancialAid");
            HasKey(t => t.FinancialAidId);
            Property(t => t.FinancialAidId)
                .IsRequired()
                .HasColumnName("FinancialAidId")
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
                .IsOptional()
                .HasColumnName("MiddleName")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(2)
                .HasMaxLength(50);
            Property(t => t.LastName)
                .IsRequired()
                .HasColumnName("LastName")
                .HasColumnOrder(3)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);
            Property(t => t.Amount)
                .IsOptional()
                .HasColumnName("Amount")
                .HasColumnOrder(4)
                .HasColumnType("DECIMAL");
            Property(t => t.OnTrack)
                .IsOptional()
                .HasColumnName("OnTrack")
                .HasColumnOrder(5)
                .HasColumnType("BIT");
            Property(t => t.Classification)
                .IsOptional()
                .HasColumnName("Classification")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(6)
                .HasMaxLength(50);
            Ignore(p => p.FullName);
            ;
        }
    }
}