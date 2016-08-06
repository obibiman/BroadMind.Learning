using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BroadMind.Common.Domain;

namespace BroadMind.DataAccess.Mapping
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            ToTable("Address");
            HasKey(t => t.AddressId);
            Property(t => t.AddressId)
                .IsRequired()
                .HasColumnName("AddressId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasColumnOrder(0)
                .HasColumnType("INT");
            Property(t => t.Address1)
                .IsRequired()
                .HasColumnName("Address1")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(2)
                .HasMaxLength(150);
            Property(t => t.Address2)
                .IsOptional()
                .HasColumnName("Adress2")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(3)
                .HasMaxLength(150);
            Property(t => t.City)
                .IsRequired()
                .HasColumnName("City")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(4)
                .HasMaxLength(100);
            Property(t => t.ZipCode)
                .IsRequired()
                .HasColumnName("ZipCode")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(5)
                .HasMaxLength(10);
            Property(t => t.CreatedDate)
                .IsRequired()
                .HasColumnName("CreatedDate")
                .HasColumnOrder(6)
                .HasColumnType("DateTime");
            Property(t => t.ModifiedDate)
                .IsOptional()
                .HasColumnName("ModifiedDate")
                .HasColumnOrder(7)
                .HasColumnType("DateTime");
            Property(t => t.ModifiedBy)
                .IsOptional()
                .HasColumnName("ModifiedBy")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(8)
                .HasMaxLength(50);
            Property(t => t.StateCode)
                .IsRequired()
                .HasColumnName("StateCode")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(9)
                .HasMaxLength(2);
            Property(t => t.Country)
                .IsOptional()
                .HasColumnName("Country")
                .HasColumnType("NVARCHAR")
                .HasColumnOrder(10)
                .HasMaxLength(25);
        }
    }
}