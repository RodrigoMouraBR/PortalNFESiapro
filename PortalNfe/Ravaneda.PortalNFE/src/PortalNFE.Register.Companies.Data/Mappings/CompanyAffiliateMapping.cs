using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalNFE.Register.Companies.Domain.Models;

namespace PortalNFE.Register.Companies.Data.Mappings
{
    public class CompanyAffiliateMapping : IEntityTypeConfiguration<CompanyAffiliate>
    {
        public void Configure(EntityTypeBuilder<CompanyAffiliate> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(p => p.DateRegister)
              .HasColumnType("timestamptz");

            builder.Property(p => p.DateChanged)
              .HasColumnType("timestamptz");

            builder.HasOne(b => b.Company)
            .WithMany(a => a.CompanyAffiliate)
            .HasForeignKey(b => b.RootCompanyId);

            builder.ToTable("Affiliate");
        }
    }
}
