using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalNFE.Register.Companies.Domain.Models;

namespace PortalNFE.Register.Companies.Data.Mappings
{
    public class CompanyAddressMapping : IEntityTypeConfiguration<CompanyAddress>
    {
        public void Configure(EntityTypeBuilder<CompanyAddress> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Street)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.CompanyId)
                .IsRequired();

            builder.Property(c => c.Number)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Neighborhood)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.City)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(c => c.State)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(c => c.Country)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(c => c.Complement)
                .IsRequired()
                .HasColumnType("varchar(140)");

            builder.Property(p => p.DateRegister)
              .HasColumnType("timestamptz");

            builder.Property(p => p.DateChanged)
              .HasColumnType("timestamptz");

            builder.ToTable("CompanyAddress");
        }
    }
}
