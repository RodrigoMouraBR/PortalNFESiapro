using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalNFE.Register.Companies.Domain.Models;
using System.Reflection.Emit;

namespace PortalNFE.Register.Companies.Data.Mappings
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CompanyName)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.FantasyName)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Document)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(p => p.Email)
               .HasColumnType("varchar(50)");

            builder.Property(p => p.Phone)
               .HasColumnType("varchar(30)");

            builder.Property(p => p.DateRegister)
               .HasColumnType("timestamptz");

            builder.Property(p => p.DateChanged)
              .HasColumnType("timestamptz");

            builder.Ignore(p => p.ValidationResult);

            builder.Ignore(p=>p.DocumentRoot);

            // 1 : 1 => Company : Address
            builder.HasOne(a => a.CompanyAddress)
                .WithOne(c => c.Company);

            builder.ToTable("Company");
        }
    }
}
