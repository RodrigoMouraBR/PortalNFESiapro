using Microsoft.EntityFrameworkCore;
using PortalNFE.Core.Interfaces;
using PortalNFE.Register.Users.Domain.Models;

namespace PortalNFE.Register.Users.Data.Context
{
    public class PortalNFEUserPersonContext : DbContext, IUnitOfWork
    {
        public PortalNFEUserPersonContext(DbContextOptions<PortalNFEUserPersonContext> options) : base(options)
        {

        }

        public DbSet<UserPerson> UserPersons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string)))) property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PortalNFEUserPersonContext).Assembly);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DateRegister") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateRegister").CurrentValue = DateTime.UtcNow;

                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DateRegister").IsModified = false;
                }
            }
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DateChanged") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateChanged").IsModified = false;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DateChanged").CurrentValue = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public async Task<bool> Commit()
        {
            try
            {
                foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DateRegister") != null))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("DateRegister").CurrentValue = DateTime.UtcNow;
                    }
                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("DateRegister").IsModified = false;
                    }
                }
                foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DateChanged") != null))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("DateChanged").IsModified = false;
                    }
                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("DateChanged").CurrentValue = DateTime.UtcNow;
                    }
                }
                var success = await base.SaveChangesAsync() > 0;
                return success;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
