using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalNFE.Register.Users.Domain.Models;

namespace PortalNFE.Register.Users.Data.Mappings
{
    public class UserPersonMapping : IEntityTypeConfiguration<UserPerson>
    {
        public void Configure(EntityTypeBuilder<UserPerson> builder)
        {
            builder.HasKey(x => x.Id);           

            builder.Property(p => p.Name)
              .HasColumnType("varchar(50)");

            builder.Property(p => p.Email)
              .HasColumnType("varchar(50)");

            builder.Property(p => p.CellPhone)
                .HasColumnType("varchar(14)");

            builder.ToTable("UserPerson");
        }
    }
}
