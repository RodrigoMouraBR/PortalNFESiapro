using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalNFE.Orders.Domain.Models;

namespace PortalNFE.Orders.Data.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.IDDEST)
               .HasColumnType("varchar(50)");

            builder.Property(p => p.INDFINAL)
              .HasColumnType("varchar(50)");

            builder.Property(p => p.INDPRES)
              .HasColumnType("varchar(50)");

            builder.Property(p => p.XPED)
              .HasColumnType("varchar(50)");

            builder.Property(p => p.NITEMPED)
              .HasColumnType("varchar(50)");

            builder.Property(p => p.CSOSN)
             .HasColumnType("varchar(50)");

            builder.Property(p => p.PCREDSN)
             .HasColumnType("varchar(50)");

            builder.Property(p => p.VCREDICMSSN)
            .HasColumnType("varchar(50)");

            builder.ToTable("Order");
        }
    }
}
